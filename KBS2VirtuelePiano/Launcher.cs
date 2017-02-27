using KBS2VirtuelePiano.Controller;
using KBS2VirtuelePiano.Model;
using KBS2VirtuelePiano.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KBS2VirtuelePiano
{
    public class Launcher
    {
        /* Constanten */
        private const int LOGIN = 0;
        private const int EDITOR = 3;

        /* Instellingen */
#if DEBUG 
        // Hier mag je aan zitten
        public static readonly bool DEBUG = true;
        public static readonly bool NEW_DATABASE = false;
#else
        // Hier moet je niet aan zitten
        public static readonly bool DEBUG = false;
        public static readonly bool NEW_DATABASE = false;
#endif

        public static readonly int START_WINDOW = LOGIN;

        public static void Main(string[] args)
        {
            /*********************************************
             * KANT-EN-KLARE DATABASE - NIET VERWIJDEREN *
             *********************************************/
            using (DatabaseContext db = new DatabaseContext())
            {

                if (db.Users.Count() < 1 || NEW_DATABASE)
                {
                    // Alles resetten
                    db.Scores.RemoveRange(db.Scores);
                    db.Users.RemoveRange(db.Users);
                    db.SongComponents.RemoveRange(db.SongComponents);
                    db.Songs.RemoveRange(db.Songs);
                    db.SaveChanges();

                    /*********
                     * Users *
                     *********/
                    User admin = new User("ADMIN", "ADMIN", "M", "Straat 1", "Zwolle", "1234ab", "admin@admin.nl", "admin", 1, true, DateTime.Now);
                    User student = new User("STUDENT", "STUDENT", "M", "Straat 1", "Zwolle", "1234ab", "student@student.nl", "student", 10, false, DateTime.Now);

                    db.Users.Add(admin);
                    db.Users.Add(student);

                    db.SaveChanges();

                    /**********
                     * Song 1 *
                     **********/
                    Song song = new Song(4, 4) { Level = 1, Author = "Joris", Name = "Prachtig liedje", BeatsPerMinute = 60 };

                    song.AutoGenerate();
                    db.Songs.Add(song);

                    db.SaveChanges();

                    /*******************
                     * Song 1 Measures *
                     *******************/
                    AddSong(db, song);

                    /**********
                     * Song 2 *
                     **********/
                    Song song2 = new Song(4, 4) { Level = 2, Author = "Iemand anders", Name = "Een iets minder prachtig liedje", BeatsPerMinute = 60 };
                    db.Songs.Add(song2);
                    db.SaveChanges();

                    Measure m1 = new Measure();
                    m1.Components.Add(new Note(NoteLetter.C, 5, false, ComponentLength.FULL, 0));
                    song2.Measures.Add(m1);
                    
                    Measure m2 = new Measure();
                    m2.Components.Add(new Note(NoteLetter.C, 5, false, ComponentLength.HALF, 0));
                    m2.Components.Add(new Note(NoteLetter.D, 5, false, ComponentLength.HALF, 4));
                    song2.Measures.Add(m2);

                    Measure m13 = new Measure();
                    m13.Components.Add(new Note(NoteLetter.G, 5, false, ComponentLength.QUARTER, 0));
                    m13.Components.Add(new Note(NoteLetter.F, 5, false, ComponentLength.QUARTER, 2));
                    m13.Components.Add(new Note(NoteLetter.E, 5, false, ComponentLength.QUARTER, 4));
                    m13.Components.Add(new Note(NoteLetter.D, 5, false, ComponentLength.QUARTER, 6));
                    song2.Measures.Add(m13);

                    Measure m14 = new Measure();
                    m14.Components.Add(new Note(NoteLetter.B, 5, false, ComponentLength.EIGHTH, 0));
                    m14.Components.Add(new Note(NoteLetter.A, 5, false, ComponentLength.EIGHTH, 1));
                    m14.Components.Add(new Note(NoteLetter.G, 5, false, ComponentLength.EIGHTH, 2));
                    m14.Components.Add(new Note(NoteLetter.F, 5, false, ComponentLength.EIGHTH, 3));

                    m14.Components.Add(new Note(NoteLetter.E, 5, false, ComponentLength.EIGHTH, 4));
                    m14.Components.Add(new Note(NoteLetter.D, 5, false, ComponentLength.EIGHTH, 5));
                    m14.Components.Add(new Note(NoteLetter.C, 5, false, ComponentLength.EIGHTH, 6));
                    m14.Components.Add(new Note(NoteLetter.A, 4, false, ComponentLength.EIGHTH, 7));

                    song2.Measures.Add(m14);
                    /*******************
                     * Song 2 Measures *
                     *******************/
                    AddSong(db, song2);

                    /**********
                     * Song 3 *
                     **********/
                    Song song3 = new Song(4, 4, 15) { Level = 2, Author = "Coldplay", Name = "Clocks", BeatsPerMinute = 45 };
                    db.Songs.Add(song3);
                    db.SaveChanges();

                    Measure m3 = new Measure();
                    m3.Components.Add(new Note(NoteLetter.E, 5, false, ComponentLength.EIGHTH, 0,1));
                    m3.Components.Add(new Note(NoteLetter.B, 4, false, ComponentLength.EIGHTH, 1,2));
                    m3.Components.Add(new Note(NoteLetter.G, 4, false, ComponentLength.EIGHTH, 2,3));
                    m3.Components.Add(new Note(NoteLetter.E, 5, false, ComponentLength.EIGHTH, 3,4));
                    m3.Components.Add(new Note(NoteLetter.E, 5, false, ComponentLength.EIGHTH, 4,5));
                    m3.Components.Add(new Note(NoteLetter.B, 4, false, ComponentLength.EIGHTH, 5,6));
                    m3.Components.Add(new Note(NoteLetter.G, 4, false, ComponentLength.EIGHTH, 6,7));
                    m3.Components.Add(new Note(NoteLetter.E, 5, false, ComponentLength.EIGHTH, 7,8));
                    song3.Measures.Add(m3);

                    Measure m4 = new Measure();
                    m4.Components.Add(new Note(NoteLetter.D, 5, false, ComponentLength.EIGHTH, 0,9));
                    m4.Components.Add(new Note(NoteLetter.B, 4, false, ComponentLength.EIGHTH, 1,10));
                    m4.Components.Add(new Note(NoteLetter.F, 4, false, ComponentLength.EIGHTH, 2,11));
                    m4.Components.Add(new Note(NoteLetter.D, 5, false, ComponentLength.EIGHTH, 3,12));
                    m4.Components.Add(new Note(NoteLetter.B, 4, false, ComponentLength.EIGHTH, 4,13));
                    m4.Components.Add(new Note(NoteLetter.F, 4, false, ComponentLength.EIGHTH, 5,14));
                    m4.Components.Add(new Note(NoteLetter.D, 5, false, ComponentLength.EIGHTH, 6,15));
                    m4.Components.Add(new Note(NoteLetter.B, 4, false, ComponentLength.EIGHTH, 7,16));
                    song3.Measures.Add(m4);
                    Measure m5 = new Measure();
                    m5.Components.Add(new Note(NoteLetter.D, 5, false, ComponentLength.EIGHTH, 0, 17));
                    m5.Components.Add(new Note(NoteLetter.B, 4, false, ComponentLength.EIGHTH, 1, 18));
                    m5.Components.Add(new Note(NoteLetter.F, 4, false, ComponentLength.EIGHTH, 2, 19));
                    m5.Components.Add(new Note(NoteLetter.D, 5, false, ComponentLength.EIGHTH, 3, 20));
                    m5.Components.Add(new Note(NoteLetter.B, 4, false, ComponentLength.EIGHTH, 4, 21));
                    m5.Components.Add(new Note(NoteLetter.F, 4, false, ComponentLength.EIGHTH, 5, 22));
                    m5.Components.Add(new Note(NoteLetter.D, 5, false, ComponentLength.EIGHTH, 6, 23));
                    m5.Components.Add(new Note(NoteLetter.B, 4, false, ComponentLength.EIGHTH, 7, 24));
                    song3.Measures.Add(m5);

                    Measure m6 = new Measure();
                    m6.Components.Add(new Note(NoteLetter.C, 5, false, ComponentLength.EIGHTH, 0, 25));
                    m6.Components.Add(new Note(NoteLetter.A, 4, false, ComponentLength.EIGHTH, 1, 26));
                    m6.Components.Add(new Note(NoteLetter.C, 4, false, ComponentLength.EIGHTH, 2, 27));
                    m6.Components.Add(new Note(NoteLetter.C, 5, false, ComponentLength.EIGHTH, 3, 28));
                    m6.Components.Add(new Note(NoteLetter.A, 4, false, ComponentLength.EIGHTH, 4, 29));
                    m6.Components.Add(new Note(NoteLetter.C, 5, false, ComponentLength.EIGHTH, 5, 30));
                    m6.Components.Add(new Note(NoteLetter.C, 5, false, ComponentLength.EIGHTH, 6, 31));
                    m6.Components.Add(new Note(NoteLetter.A, 4, false, ComponentLength.EIGHTH, 7, 32));
                    song3.Measures.Add(m6);
                    Measure m7 = new Measure();
                    m7.Components.Add(new Note(NoteLetter.E, 5, false, ComponentLength.EIGHTH, 0, 33));
                    m7.Components.Add(new Note(NoteLetter.B, 4, false, ComponentLength.EIGHTH, 1, 34));
                    m7.Components.Add(new Note(NoteLetter.G, 4, false, ComponentLength.EIGHTH, 2, 35));
                    m7.Components.Add(new Note(NoteLetter.E, 5, false, ComponentLength.EIGHTH, 3, 36));
                    m7.Components.Add(new Note(NoteLetter.E, 5, false, ComponentLength.EIGHTH, 4, 37));
                    m7.Components.Add(new Note(NoteLetter.B, 4, false, ComponentLength.EIGHTH, 5, 38));
                    m7.Components.Add(new Note(NoteLetter.G, 4, false, ComponentLength.EIGHTH, 6, 39));
                    m7.Components.Add(new Note(NoteLetter.E, 5, false, ComponentLength.EIGHTH, 7, 40));
                    song3.Measures.Add(m7);

                    Measure m8 = new Measure();
                    m8.Components.Add(new Note(NoteLetter.D, 5, false, ComponentLength.EIGHTH, 0, 41));
                    m8.Components.Add(new Note(NoteLetter.B, 4, false, ComponentLength.EIGHTH, 1, 42));
                    m8.Components.Add(new Note(NoteLetter.F, 4, false, ComponentLength.EIGHTH, 2, 43));
                    m8.Components.Add(new Note(NoteLetter.D, 5, false, ComponentLength.EIGHTH, 3, 44));
                    m8.Components.Add(new Note(NoteLetter.B, 4, false, ComponentLength.EIGHTH, 4, 45));
                    m8.Components.Add(new Note(NoteLetter.F, 4, false, ComponentLength.EIGHTH, 5, 46));
                    m8.Components.Add(new Note(NoteLetter.D, 5, false, ComponentLength.EIGHTH, 6, 47));
                    m8.Components.Add(new Note(NoteLetter.B, 4, false, ComponentLength.EIGHTH, 7, 48));
                    song3.Measures.Add(m8);
                    Measure m9 = new Measure();
                    m9.Components.Add(new Note(NoteLetter.D, 5, false, ComponentLength.EIGHTH, 0, 49));
                    m9.Components.Add(new Note(NoteLetter.B, 4, false, ComponentLength.EIGHTH, 1, 50));
                    m9.Components.Add(new Note(NoteLetter.F, 4, false, ComponentLength.EIGHTH, 2, 51));
                    m9.Components.Add(new Note(NoteLetter.D, 5, false, ComponentLength.EIGHTH, 3, 52));
                    m9.Components.Add(new Note(NoteLetter.B, 4, false, ComponentLength.EIGHTH, 4, 53));
                    m9.Components.Add(new Note(NoteLetter.F, 4, false, ComponentLength.EIGHTH, 5, 54));
                    m9.Components.Add(new Note(NoteLetter.D, 5, false, ComponentLength.EIGHTH, 6, 55));
                    m9.Components.Add(new Note(NoteLetter.B, 4, false, ComponentLength.EIGHTH, 7, 56));
                    song3.Measures.Add(m9);

                    Measure m10 = new Measure();
                    m10.Components.Add(new Note(NoteLetter.C, 5, false, ComponentLength.EIGHTH, 0, 57));
                    m10.Components.Add(new Note(NoteLetter.A, 4, false, ComponentLength.EIGHTH, 1, 58));
                    m10.Components.Add(new Note(NoteLetter.C, 4, false, ComponentLength.EIGHTH, 2, 59));
                    m10.Components.Add(new Note(NoteLetter.C, 5, false, ComponentLength.EIGHTH, 3, 60));
                    m10.Components.Add(new Note(NoteLetter.A, 4, false, ComponentLength.EIGHTH, 4, 61));
                    m10.Components.Add(new Note(NoteLetter.C, 5, false, ComponentLength.EIGHTH, 5, 62));
                    m10.Components.Add(new Note(NoteLetter.C, 5, false, ComponentLength.EIGHTH, 6, 63));
                    m10.Components.Add(new Note(NoteLetter.A, 4, false, ComponentLength.EIGHTH, 7, 64));
                    song3.Measures.Add(m10);

                    /*******************
                     * Song 3 Measures *
                     *******************/
                    AddSong(db, song3);


                    /**********
                    * Song 4 *
                    **********/

                    Song song4 = new Song(4, 4) { Level = 2, Author = "Meneer Voorbeeld", Name = "Voorbeel lied", BeatsPerMinute = 60 };
                    db.Songs.Add(song4);
                    db.SaveChanges();
                    Measure m20 = new Measure();
                    m20.Components.Add(new Rest(ComponentLength.FULL, 0));
                    song4.Measures.Add(m20);

                    Measure m21 = new Measure();
                    m21.Components.Add(new Rest(ComponentLength.HALF, 0));
                    m21.Components.Add(new Rest(ComponentLength.HALF, 4));
                    song4.Measures.Add(m21);

                    Measure m22 = new Measure();
                    m22.Components.Add(new Rest(ComponentLength.QUARTER, 0));
                    m22.Components.Add(new Rest(ComponentLength.QUARTER, 2));
                    m22.Components.Add(new Rest(ComponentLength.QUARTER, 4));
                    m22.Components.Add(new Rest(ComponentLength.QUARTER, 6));
                    song4.Measures.Add(m22);


                    Measure m23 = new Measure();
                    m23.Components.Add(new Rest(ComponentLength.EIGHTH, 0));
                    m23.Components.Add(new Rest(ComponentLength.EIGHTH, 1));
                    m23.Components.Add(new Rest(ComponentLength.EIGHTH, 2));
                    m23.Components.Add(new Rest(ComponentLength.EIGHTH, 3));
                    m23.Components.Add(new Rest(ComponentLength.EIGHTH, 4));
                    m23.Components.Add(new Rest(ComponentLength.EIGHTH, 5));
                    m23.Components.Add(new Rest(ComponentLength.EIGHTH, 6));
                    m23.Components.Add(new Rest(ComponentLength.EIGHTH, 7));
                    song4.Measures.Add(m23);

                    Measure m24 = new Measure();
                    m24.Components.Add(new Note(NoteLetter.A, 5, false, ComponentLength.EIGHTH, 0));
                    m24.Components.Add(new Note(NoteLetter.B, 5, false, ComponentLength.EIGHTH, 1));
                    m24.Components.Add(new Rest(ComponentLength.EIGHTH, 2));
                    m24.Components.Add(new Note(NoteLetter.C, 5, false, ComponentLength.EIGHTH, 3));
                    m24.Components.Add(new Note(NoteLetter.G, 4, false, ComponentLength.QUARTER, 4));
                    m24.Components.Add(new Rest(ComponentLength.QUARTER, 6));
                    song4.Measures.Add(m24);

                    AddSong(db, song4);
                    /**********
                     * Score *
                     **********/
                    Score score = new Score() { SongID = song.SongID, UserID = student.UserID, Percentage = 0.5M, Date = DateTime.Now };
                    db.Scores.Add(score);
                    score = new Score() { SongID = song.SongID, UserID = student.UserID, Percentage = 0.8M, Date = DateTime.Now };
                    db.Scores.Add(score);

                    Score score2 = new Score() { SongID = song2.SongID, UserID = student.UserID, Percentage = 0.3M, Date = DateTime.Now };
                    db.Scores.Add(score2);
                    score2 = new Score() { SongID = song2.SongID, UserID = student.UserID, Percentage = 0.5M, Date = DateTime.Now };
                    db.Scores.Add(score2);

                    Score score3 = new Score() { SongID = song2.SongID, UserID = student.UserID, Percentage = 0.7M, Date = DateTime.Now };
                    db.Scores.Add(score3);


                    score3 = new Score() { SongID = song2.SongID, UserID = student.UserID, Percentage = 0.8M, Date = DateTime.Now };
                    db.Scores.Add(score3);
                    db.SaveChanges();
                    
                }
            }

            // Bepaal welke te starten
            switch(START_WINDOW)
            {
                case LOGIN:
                    new WindowLoginController().Run();
                    return;
                case EDITOR:
                    //Is te bereiken via owner
                    return;
            }
        }

        private static void AddSong(DatabaseContext db, Song s)
        {
            int mID = 0;
            foreach (Measure m in s.Measures)
            {
                foreach (SongComponent sc in m.Components)
                {
                    sc.songID = s.SongID;
                    sc.AbsoluteX = (mID * s.GetXPerMeasure()) + sc.X;

                    db.SongComponents.Add(sc);
                }
                mID++;
            }
            db.SaveChanges();
        }
    }
}
