using System;
using System.Linq;

namespace _01.School
{
    public interface ICommentable
    {
        void AddComment(string comment);
        void RemoveComment(int commentPosition);
        void PrintComments();
    }
}
