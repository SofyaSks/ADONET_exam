using JournalDiary;
using Microsoft.EntityFrameworkCore;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class TeacherGroupSubjectsVm : BindableBase, IEditableObject
    {
        public TeacherGroupSubject TeacherGroupSubject { get; set; }
        public Teacher Teacher { get; set; }
        public Group Group { get; set; }
        public Subject Subject { get; set; }
        public IReadOnlyList<Teacher> Teachers { get; }
        public IReadOnlyList<Group> Groups { get; }
        public IReadOnlyList<Subject> Subjects { get; }

        private bool isEditing = false;

        public TeacherGroupSubjectsVm(TeacherGroupSubject teacherGroupSubject, IReadOnlyList<Teacher> teachers, IReadOnlyList<Group> groups, IReadOnlyList<Subject> subjects)
        {
            TeacherGroupSubject = teacherGroupSubject;
            Teachers = teachers;
            Groups = groups;
            Subjects = subjects;
        }

        public TeacherGroupSubjectsVm(IReadOnlyList<Teacher> teachers, IReadOnlyList<Group> groups, IReadOnlyList<Subject> subjects)
        {

            Teachers = teachers;
            Groups = groups;
            Subjects = subjects;
        }
        public void BeginEdit()
        {
            isEditing = true;
        }

        public void CancelEdit()
        {
            isEditing = false;
        }

        public async void EndEdit()
        {
            if (!isEditing) return;
            isEditing = false;

            JournalDiaryDbContext db = new();

            TeacherGroupSubject clone = new TeacherGroupSubject
            {
                Id = TeacherGroupSubject.Id,
                Teacher = null,
                TeacherId = TeacherGroupSubject.Teacher.Id,
                Group = null,
                GroupId = TeacherGroupSubject.Group.Id,
                Subject = null,
                SubjectId = TeacherGroupSubject.Subject.Id,
            };

            db.TeacherGroupSubjects.Entry(clone)
                .State = TeacherGroupSubject.Id == 0 ? EntityState.Added : EntityState.Modified;

            await db.SaveChangesAsync();
        }


    }
}
