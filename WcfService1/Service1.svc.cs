using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.Entity.Validation;

namespace WcfService1
{
    [ServiceBehavior(InstanceContextMode =InstanceContextMode.Single)]

    public class Service1 : IService1
    {
        PIb_162_BeloborodovaEntities db = new PIb_162_BeloborodovaEntities();
        List<ServerUser> users = new List<ServerUser>();
        public List<string> listMsg = new List<string>();

        public void addAuthor(string name, string sname)
        {
            T_Author record = new T_Author();
            record.A_name = name;
            record.A_surname = sname;
            db.T_Author.Add(record);
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                string sEnt = "";
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    sEnt += "Object: " + validationError.Entry.Entity.ToString();
                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        sEnt += err.ErrorMessage + "\t";
                    }
                    sEnt += "\n";
                }
                writeError("TestRequestService_ent_" + sEnt);
            }
            catch (Exception exp)
            {
                writeError(exp.Message);
            }
        }

        public void addBook(int id_genre, int id_author, string book_name, bool available)
        {
            T_Book record = new T_Book();
            record.ID_author = id_author;
            record.ID_genre = id_genre;
            record.Book_name = book_name;
            record.Available = available;
            db.T_Book.Add(record);
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                string sEnt = "";
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    sEnt += "Object: " + validationError.Entry.Entity.ToString();
                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        sEnt += err.ErrorMessage + "\t";
                    }
                    sEnt += "\n";
                }
                writeError("TestRequestService_ent_" + sEnt);
            }
            catch (Exception exp)
            {
                writeError(exp.Message);
            }
        }

        public void addGenre(string genre_name, string color)
        {
            T_Genre record = new T_Genre();
            record.Genre_name = genre_name;
            record.Color = color;
            db.T_Genre.Add(record);
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                string sEnt = "";
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    sEnt += "Object: " + validationError.Entry.Entity.ToString();
                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        sEnt += err.ErrorMessage + "\t";
                    }
                    sEnt += "\n";
                }
                writeError("TestRequestService_ent_" + sEnt);
            }
            catch (Exception exp)
            {
                writeError(exp.Message);
            }

        }

        public void addJournal(int id_book, int id_reader)
        {
            T_Journal record = new T_Journal();
            record.ID_book = id_book;
            record.ID_reader = id_reader;
            record.Date_issue = DateTime.Now;
            db.T_Journal.Add(record);
            try
            {
                db.SaveChanges();
            }

            catch (DbEntityValidationException ex)
            {
                string sEnt = "";
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    sEnt += "Object: " + validationError.Entry.Entity.ToString();
                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        sEnt += err.ErrorMessage + "\t";
                    }
                    sEnt += "\n";
                }
                writeError("TestRequestService_ent_" + sEnt);
            }
            catch (Exception exp)
            {
                writeError(exp.Message);
            }
        }

        public void addReader(string name, string sname)
        {
            T_Reader record = new T_Reader();
            record.R_name = name;
            record.R_surname = sname;
            record.Reg_date = DateTime.Now;
            db.T_Reader.Add(record);
            try
            {
                db.SaveChanges();

            }
            catch (DbEntityValidationException ex)
            {
                string sEnt = "";
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    sEnt += "Object: " + validationError.Entry.Entity.ToString();
                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        sEnt += err.ErrorMessage + "\t";
                    }
                    sEnt += "\n";
                }
                writeError("TestRequestService_ent_" + sEnt);
            }
            catch (Exception exp)
            {
                writeError(exp.Message);
            }
        }

        public int Connect(int id)
        {
            ServerUser Suser = new ServerUser();
            T_Reader user = new T_Reader();
            user = db.T_Reader.Where(b => b.ID_reader == id).FirstOrDefault();

            Suser.ID_reader = user.ID_reader;
            Suser.R_name = user.R_name;
            Suser.R_surname = user.R_surname;
            Suser.Login = user.Login;
            Suser.operationContext = OperationContext.Current;

            users.Add(Suser);
            sendMsg(Suser.Login + "(" + Suser.R_name + " " + Suser.R_surname + "присоединился к чату", 0);
            return Suser.ID_reader;
        }

        public void deleteAuthor(int id)
        {
            T_Author record = db.T_Author.Where(o => o.ID_author == id).FirstOrDefault();
            if (record!=null )
            {
                db.T_Author.Remove(record);
                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    string sEnt = "";
                    foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                    {
                        sEnt += "Object: " + validationError.Entry.Entity.ToString();
                        foreach (DbValidationError err in validationError.ValidationErrors)
                        {
                            sEnt += err.ErrorMessage + "\t";
                        }
                        sEnt += "\n";
                    }
                    writeError("TestRequestService_ent_" + sEnt);
                }
                catch (Exception exp)
                {
                    writeError(exp.Message);
                }
            }
        }

        public void deleteBook(int id)
        {
            T_Book record = db.T_Book.Where(o => o.ID_book == id).FirstOrDefault();
            if (record != null)
            {
                db.T_Book.Remove(record);
                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    string sEnt = "";
                    foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                    {
                        sEnt += "Object: " + validationError.Entry.Entity.ToString();
                        foreach (DbValidationError err in validationError.ValidationErrors)
                        {
                            sEnt += err.ErrorMessage + "\t";
                        }
                        sEnt += "\n";
                    }
                    writeError("TestRequestService_ent_" + sEnt);
                }
                catch (Exception exp)
                {
                    writeError(exp.Message);
                }
            }
        }

        public void deleteGenre(int id)
        {
            T_Genre record = db.T_Genre.Where(o => o.ID_genre == id).FirstOrDefault();
            if (record != null)
            {
                db.T_Genre.Remove(record);
                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    string sEnt = "";
                    foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                    {
                        sEnt += "Object: " + validationError.Entry.Entity.ToString();
                        foreach (DbValidationError err in validationError.ValidationErrors)
                        {
                            sEnt += err.ErrorMessage + "\t";
                        }
                        sEnt += "\n";
                    }
                    writeError("TestRequestService_ent_" + sEnt);
                }
                catch (Exception exp)
                {
                    writeError(exp.Message);
                }
            }
        }

        public void deleteJournal(int id)
        {
            T_Journal record = db.T_Journal.Where(o => o.ID_journal == id).FirstOrDefault();
            if (record != null)
            {
                db.T_Journal.Remove(record);
                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    string sEnt = "";
                    foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                    {
                        sEnt += "Object: " + validationError.Entry.Entity.ToString();
                        foreach (DbValidationError err in validationError.ValidationErrors)
                        {
                            sEnt += err.ErrorMessage + "\t";
                        }
                        sEnt += "\n";
                    }
                    writeError("TestRequestService_ent_" + sEnt);
                }
                catch (Exception exp)
                {
                    writeError(exp.Message);
                }
            }
        }

        public void deleteReader(int id)
        {
            T_Reader record = db.T_Reader.Where(o => o.ID_reader == id).FirstOrDefault();
            if (record != null)
            {
                db.T_Reader.Remove(record);
                try
                {
                    db.SaveChanges();

                }
                catch (DbEntityValidationException ex)
                {
                    string sEnt = "";
                    foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                    {
                        sEnt += "Object: " + validationError.Entry.Entity.ToString();
                        foreach (DbValidationError err in validationError.ValidationErrors)
                        {
                            sEnt += err.ErrorMessage + "\t";
                        }
                        sEnt += "\n";
                    }
                    writeError("TestRequestService_ent_" + sEnt);
                }
                catch (Exception exp)
                {
                    writeError(exp.Message);
                }
            }
        }

        public void Disconnect(int id)
        {
            var Suser = users.Find(b => b.ID_reader == id);
            if(Suser!=null)
            {
                users.Remove(Suser);
                sendMsg(Suser.Login + "(" + Suser.R_name + " " + Suser.R_surname + "покинул чат", 0);
            }

        }

        public void editAuthor(int id, string name, string sname)
        {
            T_Author record = db.T_Author.Single(b => b.ID_author == id);
            record.A_name = name;
            record.A_surname = sname;
            try
            {
                db.SaveChanges();

            }
            catch (DbEntityValidationException ex)
            {
                string sEnt = "";
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    sEnt += "Object: " + validationError.Entry.Entity.ToString();
                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        sEnt += err.ErrorMessage + "\t";
                    }
                    sEnt += "\n";
                }
                writeError("TestRequestService_ent_" + sEnt);
            }
            catch (Exception exp)
            {
                writeError(exp.Message);
            }
        }

        public void editBook(int id, int author, int genre, string book_name, bool available)
        {
            T_Book record = db.T_Book.Single(b => b.ID_book == id);
            record.ID_author = author;
            record.ID_genre = genre;
            record.Book_name = book_name;
            record.Available = available;
            try
            {
                db.SaveChanges();

            }
            catch (DbEntityValidationException ex)
            {
                string sEnt = "";
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    sEnt += "Object: " + validationError.Entry.Entity.ToString();
                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        sEnt += err.ErrorMessage + "\t";
                    }
                    sEnt += "\n";
                }
                writeError("TestRequestService_ent_" + sEnt);
            }
            catch (Exception exp)
            {
                writeError(exp.Message);
            }
        }

        public void editGenre(int id, string genre_name, string color)
        {
            T_Genre record = db.T_Genre.Single(b => b.ID_genre == id);
            record.Genre_name = genre_name;
            record.Color = color;
            try
            {
                db.SaveChanges();

            }
            catch (DbEntityValidationException ex)
            {
                string sEnt = "";
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    sEnt += "Object: " + validationError.Entry.Entity.ToString();
                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        sEnt += err.ErrorMessage + "\t";
                    }
                    sEnt += "\n";
                }
                writeError("TestRequestService_ent_" + sEnt);
            }
            catch (Exception exp)
            {
                writeError(exp.Message);
            }
        }

        public void editJournal(int id, int id_book, int id_reader)
        {
            T_Journal record = db.T_Journal.Single(b => b.ID_journal == id);
            record.ID_book = id_book;
            record.ID_reader = id_reader;
            record.Date_issue = DateTime.Now;
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                string sEnt = "";
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    sEnt += "Object: " + validationError.Entry.Entity.ToString();
                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        sEnt += err.ErrorMessage + "\t";
                    }
                    sEnt += "\n";
                }
                writeError("TestRequestService_ent_" + sEnt);
            }
            catch (Exception exp)
            {
                writeError(exp.Message);
            }
        }

        public void editReader(int id, string name, string sname)
        {
            T_Reader record = db.T_Reader.Single(b => b.ID_reader == id);
            record.R_name = name;
            record.R_surname = sname;
            record.Reg_date = DateTime.Now;
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                string sEnt = "";
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    sEnt += "Object: " + validationError.Entry.Entity.ToString();
                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        sEnt += err.ErrorMessage + "\t";
                    }
                    sEnt += "\n";
                }
                writeError("TestRequestService_ent_" + sEnt);
            }
            catch (Exception exp)
            {
                writeError(exp.Message);
            }
        }

        public List<T_Book> filterAuthor(int id)
        {
            List<T_Book> books = new List<T_Book>();
            foreach(T_Book item in db.T_Book.Where(b=>b.ID_author==id))
            {
                T_Book temp = new T_Book();
                temp.ID_book = item.ID_book;
                temp.Available = item.Available;
                temp.Book_name = item.Book_name;
                temp.T_Genre = new T_Genre();
                temp.T_Genre.ID_genre = item.T_Genre.ID_genre;
                temp.T_Genre.Genre_name = item.T_Genre.Genre_name;
                temp.T_Author = new T_Author();
                temp.T_Author.ID_author = item.T_Author.ID_author;
                temp.T_Author.A_surname = item.T_Author.A_surname;
                books.Add(temp);
            }
            return books;
        }

        public List<T_Book> filterAvailable(bool available)
        {
            List<T_Book> books = new List<T_Book>();
            foreach (T_Book item in db.T_Book.Where(b => b.Available == available))
            {
                T_Book temp = new T_Book();
                temp.ID_book = item.ID_book;
                temp.Available = item.Available;
                temp.Book_name = item.Book_name;
                temp.T_Genre = new T_Genre();
                temp.T_Genre.ID_genre = item.T_Genre.ID_genre;
                temp.T_Genre.Genre_name = item.T_Genre.Genre_name;
                temp.T_Author = new T_Author();
                temp.T_Author.ID_author = item.T_Author.ID_author;
                temp.T_Author.A_surname = item.T_Author.A_surname;
                books.Add(temp);
            }
            return books;
        }

        public List<T_Book> filterGenre(int id)
        {
            List<T_Book> books = new List<T_Book>();
            foreach (T_Book item in db.T_Book.Where(b => b.ID_genre == id))
            {
                T_Book temp = new T_Book();
                temp.ID_book = item.ID_book;
                temp.Available = item.Available;
                temp.Book_name = item.Book_name;
                temp.T_Genre = new T_Genre();
                temp.T_Genre.ID_genre = item.T_Genre.ID_genre;
                temp.T_Genre.Genre_name = item.T_Genre.Genre_name;
                temp.T_Author = new T_Author();
                temp.T_Author.ID_author = item.T_Author.ID_author;
                temp.T_Author.A_surname = item.T_Author.A_surname;
                books.Add(temp);
            }
            return books;
        }

        public int logIn(string login, string password)
        {
            if (login == "")
                return -1;
            else if (password == "")
                return -2;
            else if (db.T_Reader.SingleOrDefault(b => b.Login == login) == null)
                return -3;
            else if (db.T_Reader.SingleOrDefault(b => b.Login == login).Password != password)
                return -4;
            else
                return (db.T_Reader.SingleOrDefault(b => b.Login == login).ID_reader);
        }

        public List<T_Book_my> resetBooks(int id)
        {
            List<T_Book_my> books = new List<T_Book_my>();
            foreach (T_Book item in db.T_Book)
            {
                T_Book_my temp = new T_Book_my();
                temp.ID_book = item.ID_book;
                temp.Available = item.Available;
                temp.Book_name = item.Book_name;
                temp.T_Genre = new T_Genre();
                temp.T_Genre.ID_genre = item.T_Genre.ID_genre;
                temp.T_Genre.Genre_name = item.T_Genre.Genre_name;
                temp.T_Author = new T_Author();
                temp.T_Author.ID_author = item.T_Author.ID_author;
                temp.T_Author.A_surname = item.T_Author.A_surname;
                if (id == 1)
                {
                    temp.enableButton = true;
                    temp.isAdmin = 1;
                }
                else
                {
                    temp.enableButton = id == item.ID_user;
                    temp.isAdmin = 0;
                }
                books.Add(temp);
            }
            return books;
        }

        public int saveUser(string name, string surname, string login, string password)
        {
            if (login == "")
                return -1;
            else if (password == "")
                return -2;
            else if (db.T_Reader.SingleOrDefault(b => b.Login == login) != null)
                return -3;
            else
            {
                T_Reader record = new T_Reader();
                record.R_name = name;
                record.R_surname = surname;
                record.Reg_date = DateTime.Now;
                record.Login = login;
                record.Password = password;
                db.T_Reader.Add(record);
                try
                {
                    db.SaveChanges();

                }
                catch (DbEntityValidationException ex)
                {
                    string sEnt = "";
                    foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                    {
                        sEnt += "Object: " + validationError.Entry.Entity.ToString();
                        foreach (DbValidationError err in validationError.ValidationErrors)
                        {
                            sEnt += err.ErrorMessage + "\t";
                        }
                        sEnt += "\n";
                    }
                    writeError("TestRequestService_ent_" + sEnt);
                }
                catch (Exception exp)
                {
                    writeError(exp.Message);
                }

                return (db.T_Reader.SingleOrDefault(b => b.Login == login).ID_reader);
            }
        }

        public List<T_Book> searchBook(string name)
        {
            List<T_Book> result = new List<T_Book>();
            foreach(T_Book item in db.T_Book.Where(b=>b.Book_name == name))
            {
                T_Book temp = new T_Book();
                temp.ID_book = item.ID_book;
                temp.Available = item.Available;
                temp.Book_name = item.Book_name;
                temp.T_Genre = new T_Genre();
                temp.T_Genre.ID_genre = item.T_Genre.ID_genre;
                temp.T_Genre.Genre_name = item.T_Genre.Genre_name;
                temp.T_Author = new T_Author();
                temp.T_Author.ID_author = item.T_Author.ID_author;
                temp.T_Author.A_surname = item.T_Author.A_surname;
                result.Add(temp);
            }
            return result;
        }

        public List<T_Author> selectAllAuthor()
        {
            List<T_Author> authors = new List<T_Author>();
            foreach (T_Author item in db.T_Author)
            {
                T_Author temp = new T_Author();
                temp.ID_author = item.ID_author;
                temp.A_name = item.A_name;
                temp.A_surname = item.A_surname;

                authors.Add(temp);
            }

            return authors;
        }

        public List<T_Book_my> selectAllBook(int user_id, int author_id, int genre_id, string book_name, bool? isAvailable, bool allAvailable)
        {
            List<T_Book_my> books = new List<T_Book_my>();
            var all = db.T_Book.Where(o=>o.ID_book >0);
            if (author_id != -1)
                all = all.Where(o => o.ID_author == author_id);
            if (book_name!="")
                all = all.Where(o => o.Book_name  == book_name);
            if (genre_id!= -1)
                all = all.Where(o => o.ID_genre == genre_id);
            if(!allAvailable)
                all = all.Where(o => o.Available == isAvailable);

            foreach (T_Book item in all)
            {
                T_Book_my temp = new T_Book_my();
                temp.ID_book = item.ID_book;
                temp.Available = item.Available;
                temp.Book_name = item.Book_name;
                temp.T_Genre = new T_Genre();
                temp.T_Genre.ID_genre = item.T_Genre.ID_genre;
                temp.T_Genre.Genre_name = item.T_Genre.Genre_name;
                temp.T_Author = new T_Author();
                temp.T_Author.ID_author = item.T_Author.ID_author;
                temp.T_Author.A_surname = item.T_Author.A_surname;
                if (user_id == 1)
                {
                    temp.enableButton = true;
                    temp.isAdmin = 1;
                }
                else
                {
                    temp.enableButton = user_id == item.ID_user;
                    temp.isAdmin = 0;
                }
                books.Add(temp);
            }
            return books;
        }

        public List<T_Genre> selectAllGenre()
        {
            List<T_Genre> genres = new List<T_Genre>();
            foreach (T_Genre item in db.T_Genre)
            {
                T_Genre temp = new T_Genre();
                temp.ID_genre = item.ID_genre;
                temp.Genre_name = item.Genre_name;
                temp.Color = item.Color;
                genres.Add(temp);
            }
            return genres;
        }

        public List<T_Journal> selectAllJournal()
        {
            List<T_Journal> journals = new List<T_Journal>();
            foreach (T_Journal item in db.T_Journal)
            {
                T_Journal temp = new T_Journal();
                temp.ID_journal = item.ID_journal;
                temp.T_Book = new T_Book();
                temp.T_Book.ID_book = item.T_Book.ID_book;
                temp.T_Book.Book_name = item.T_Book.Book_name;
                temp.T_Reader = new T_Reader();
                temp.T_Reader.ID_reader = item.T_Reader.ID_reader;
                temp.T_Reader.R_surname = item.T_Reader.R_surname;
                temp.Date_issue = item.Date_issue;

                journals.Add(temp);
            }
            return journals;
        }

        public List<T_Reader> selectAllReader()
        {
            List<T_Reader> readers = new List<T_Reader>();
            foreach (T_Reader item in db.T_Reader)
            {
                T_Reader temp = new T_Reader();
                temp.ID_reader = item.ID_reader;
                temp.Reg_date = item.Reg_date;
                temp.R_name = item.R_name;
                temp.R_surname = item.R_surname;
                readers.Add(temp);
            }
            return readers;
        }

        public void sendMsg(string message, int id)
        {
            foreach(var item in users)
            {
                string answer = DateTime.Now.ToShortTimeString();

                var Suser = users.Find(b => b.ID_reader == id);
                if (Suser != null)
                    answer += ": " + Suser.Login + ": ";

                answer += message;

                //item.operationContext.GetCallbackChannel<IServerChatCallback>().msgCallback(message, id);
            }
        }

        public void writeError(string error)
        {
            T_Errors record = new T_Errors();
            record.Message = error;
            record.Error_date = DateTime.Now;
            db.T_Errors.Add(record);
            db.SaveChanges();
        }

        public string sendMessage(string message, int id)
        {
            string answer = DateTime.Now.ToShortTimeString();

            T_Reader user = db.T_Reader.Where(b => b.ID_reader == id).FirstOrDefault();
            if (user != null)
                answer += ": " + user.Login + ": ";

            answer += message;
            listMsg.Add(answer);

            T_Messages item = new T_Messages();
            item.Message = answer;
            db.T_Messages.Add(item);
            db.SaveChanges();

            return answer;
        }

        public List<string> checkForMessage(int count, int current)
        {
            List<string> messages = new List<string>();

            if(db.T_Messages.Count()-current !=count)
            {
                foreach(T_Messages item in db.T_Messages)
                {
                    messages.Add(item.Message);
                }
                messages.RemoveRange(0, current);
            }

            return messages;
        }

        public int currentMsg()
        {
            return db.T_Messages.Count();
        }

        public List<T_Report> selectReport()
        {
            List<T_Report> result = new List<T_Report>();

            foreach(T_Reader item in db.T_Reader)
            {
                T_Report temp = new T_Report();
                temp.ID_reader = item.ID_reader;
                temp.R_name = item.R_name;
                temp.R_surname = item.R_surname;

                temp.Books = db.T_Journal.Where(b => b.T_Reader.ID_reader == temp.ID_reader).Count();

                int count = db.T_Book.Count();
                temp.Percent = temp.Books*100 / count;

                if (temp.ID_reader != 1)
                    result.Add(temp);
            }

            return result;
        }
    }
    public class T_Book_my : T_Book
    {
        public float isAdmin { get; set; }
        public bool enableButton { get; set; }
    }

    public class T_Report
    {
        public int ID_reader { get; set; }
        public string R_surname { get; set; }
        public string R_name { get; set; }
        public int Books { get; set; }
        public int Percent { get; set; }
    }
}
