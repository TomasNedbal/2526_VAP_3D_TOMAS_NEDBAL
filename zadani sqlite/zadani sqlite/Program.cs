using Microsoft.Data.Sqlite;

class Program
{
    static void Main()
    {
        SqliteConnection conn = new SqliteConnection("Data Source=notes.db");
        conn.Open();

        SqliteCommand cmd = conn.CreateCommand();
        cmd.CommandText =
            "CREATE TABLE IF NOT EXISTS Notes (" +
            "Id INTEGER PRIMARY KEY AUTOINCREMENT," +
            "Title TEXT," +
            "Description TEXT)";
        cmd.ExecuteNonQuery();

        conn.Close();

        bool run = true;

        while (run)
        {
            Console.WriteLine();
            Console.WriteLine("1 pridat zaznam");
            Console.WriteLine("2 vypsat zaznamy");
            Console.WriteLine("3 smazat zaznam");
            Console.WriteLine("4 konec");
            Console.Write("vyber: ");

            string volba = Console.ReadLine();

            if (volba == "1")
            {
                AddNote();
            }
            else if (volba == "2")
            {
                ShowNotes();
            }
            else if (volba == "3")
            {
                DeleteNote();
            }
            else if (volba == "4")
            {
                run = false;
            }
            else
            {
                Console.WriteLine("spatna volba");
            }
        }
    }

    static void AddNote()
    {
        Console.Write("nazev: ");
        string title = Console.ReadLine();

        Console.Write("popis: ");
        string desc = Console.ReadLine();

        SqliteConnection conn = new SqliteConnection("Data Source=notes.db");
        conn.Open();

        SqliteCommand cmd = conn.CreateCommand();
        cmd.CommandText =
            "INSERT INTO Notes (Title, Description) VALUES (@t, @d)";
        cmd.Parameters.AddWithValue("@t", title);
        cmd.Parameters.AddWithValue("@d", desc);
        cmd.ExecuteNonQuery();

        conn.Close();

        Console.WriteLine("ulozeno");
    }

    static void ShowNotes()
    {
        SqliteConnection conn = new SqliteConnection("Data Source=notes.db");
        conn.Open();

        SqliteCommand cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT * FROM Notes";

        SqliteDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine(
                reader.GetInt32(0) + " " +
                reader.GetString(1) + " " +
                reader.GetString(2)
            );
        }

        conn.Close();
    }

    static void DeleteNote()
    {
        Console.Write("id: ");
        int id = int.Parse(Console.ReadLine());

        SqliteConnection conn = new SqliteConnection("Data Source=notes.db");
        conn.Open();

        SqliteCommand cmd = conn.CreateCommand();
        cmd.CommandText = "DELETE FROM Notes WHERE Id = @id";
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();

        conn.Close();

        Console.WriteLine("smazano");
    }
}
