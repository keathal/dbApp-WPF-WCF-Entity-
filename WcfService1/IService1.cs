using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    [ServiceContract/*(CallbackContract =typeof(IServerChatCallback))*/]
    public interface IService1
    {
        [OperationContract]
        List<T_Book_my> resetBooks(int id);

        [OperationContract]
        List<T_Book_my> selectAllBook(int user_id, int author_id, int genre_id, string book_name, bool? isAvailable, bool allAvailable);

        [OperationContract]
        List<T_Genre> selectAllGenre();

        [OperationContract]
        List<T_Author> selectAllAuthor();

        [OperationContract]
        List<T_Reader> selectAllReader();

        [OperationContract]
        List<T_Journal> selectAllJournal();

        [OperationContract]
        void editBook(int id, int author, int genre, string book_name, bool available);

        [OperationContract]
        void editGenre(int id, string genre_name, string color);

        [OperationContract]
        void editAuthor(int id, string name, string sname);

        [OperationContract]
        void editReader(int id, string name, string sname);

        [OperationContract]
        void editJournal(int id, int id_book, int id_reader);

        [OperationContract]
        void deleteBook(int id);

        [OperationContract]
        void deleteGenre(int id);

        [OperationContract]
        void deleteAuthor(int id);

        [OperationContract]
        void deleteReader(int id);

        [OperationContract]
        void deleteJournal(int id);

        [OperationContract]
        void addBook(int id_genre, int id_author, string book_name, bool available);

        [OperationContract]
        void addGenre(string genre_name, string color);

        [OperationContract]
        void addReader(string name, string sname);

        [OperationContract]
        void addAuthor(string name, string sname);

        [OperationContract]
        void addJournal(int id_book, int id_reader);

        [OperationContract]
        List<T_Book> searchBook(string name);

        [OperationContract]
        void writeError(string error);

        [OperationContract]
        List<T_Book> filterGenre(int id);

        [OperationContract]
        List<T_Book> filterAuthor(int id);

        [OperationContract]
        List<T_Book> filterAvailable(bool available);

        [OperationContract]
        int saveUser(string name, string surname, string login, string password);

        [OperationContract]
        int logIn(string login, string password);

        [OperationContract]
        int Connect(int id);

        [OperationContract]
        void Disconnect(int id);

        [OperationContract(IsOneWay =true)]
        void sendMsg(string message, int id);

        [OperationContract]
        string sendMessage(string message, int id);

        [OperationContract]
        List<string> checkForMessage(int count, int current);

        [OperationContract]
        int currentMsg();

        [OperationContract]
        List<T_Report> selectReport();
    }

   /* public interface IServerChatCallback
    {
        [OperationContract(IsOneWay =true)]
        void msgCallback(string message, int id);
    }*/

}
