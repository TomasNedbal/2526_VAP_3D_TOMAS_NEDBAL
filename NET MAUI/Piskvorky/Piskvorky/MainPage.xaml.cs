namespace Piskvorky;

public partial class MainPage : ContentPage
{
    string player = "X";

    public MainPage()
    {
        InitializeComponent();
    }

    void Play(object sender, EventArgs e)
    {
        Button b = (Button)sender;
        if (b.Text == "")
        {
            b.Text = player;

            // nejprve kontrola výhry
            if (CheckWinner())
            {
                DisplayAlert("Konec hry", $"Vyhrál hráč {player}!", "OK");
                ResetBoard();
                return;
            }

            // kontrola remízy
            if (CheckDraw())
            {
                DisplayAlert("Konec hry", "Remíza!", "OK");
                ResetBoard();
                return;
            }

            // přepnutí hráče
            player = player == "X" ? "O" : "X";
        }
    }

    void ResetGame(object sender, EventArgs e)
    {
        ResetBoard();
    }

    void ResetBoard()
    {
        foreach (var item in Board.Children)
        {
            if (item is Button btn) btn.Text = "";
        }
        player = "X";
    }

    void ToggleTheme(object sender, EventArgs e)
    {
        Application.Current.UserAppTheme =
            Application.Current.UserAppTheme == AppTheme.Dark ? AppTheme.Light : AppTheme.Dark;
    }

    bool CheckWinner()
    {
        Button[,] b = new Button[3, 3];
        foreach (Button btn in Board.Children)
            b[Grid.GetRow(btn), Grid.GetColumn(btn)] = btn;

        // řádky
        for (int i = 0; i < 3; i++)
            if (!string.IsNullOrEmpty(b[i, 0].Text) && b[i, 0].Text == b[i, 1].Text && b[i, 1].Text == b[i, 2].Text)
                return true;

        // sloupce
        for (int i = 0; i < 3; i++)
            if (!string.IsNullOrEmpty(b[0, i].Text) && b[0, i].Text == b[1, i].Text && b[1, i].Text == b[2, i].Text)
                return true;

        // diagonály
        if (!string.IsNullOrEmpty(b[0, 0].Text) && b[0, 0].Text == b[1, 1].Text && b[1, 1].Text == b[2, 2].Text)
            return true;

        if (!string.IsNullOrEmpty(b[0, 2].Text) && b[0, 2].Text == b[1, 1].Text && b[1, 1].Text == b[2, 0].Text)
            return true;

        return false;
    }

    bool CheckDraw()
    {
        // pokud všechny buttony mají X nebo O a nikdo nevyhrál
        foreach (Button btn in Board.Children)
        {
            if (string.IsNullOrEmpty(btn.Text))
                return false;
        }
        return true;
    }
}