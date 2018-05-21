﻿using System;
using System.IO;
using System.Threading;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace _20180407_SpaceInvaders
{
    public partial class frmSpaceInvaders : Form
    {
        // conto intermittenza
        private byte nFlash;

        // contatori
        private byte i;
        private byte j;

        private const byte nAlieni = 21;
        private const byte lungOb = 18, altOb = 8;

        private bool _moveLeft;
        private bool _moveRight;

        private bool click = true;
        private bool creati;
        private bool invincibile = false;

        private int x, y;
        private int life;

        private string maxName;
        private int maxScore = 0;

        private int direzioneAlieni = 1;
        private byte rateFuoco = 30;

        // lunghezze "logiche" degli ostacoli
        private byte[] lung0 = new byte[lungOb], lung1 = new byte[lungOb];
        private byte[] lungA0 = new byte[lungOb], lungA1 = new byte[lungOb];

        private byte level = 1;

        List<PictureBox> listaFuoco = new List<PictureBox>();
        List<PictureBox> listaFuocoNemico = new List<PictureBox>();

        List<Control> aliens = new List<Control>(nAlieni);

        List<List<PictureBox>> obstacle = new List<List<PictureBox>>(lungOb);
        List<List<PictureBox>> obstacle1 = new List<List<PictureBox>>(lungOb);

        Random rand = new Random();

        Stopwatch stopwatch = new Stopwatch();
        Stopwatch swColpito = new Stopwatch();

        /**************************************** INIZIO PROGRAMMA ****************************************/
        public frmSpaceInvaders()
        {
            InitializeComponent();
            timeMove.Tick += timeMove_Tick;
        }

        private void frmSpaceInvaders_Load(object sender, EventArgs e)
        {
            Form frmStart = new frmStart();
            if (frmStart.ShowDialog() != DialogResult.OK)
                Close();

            if (File.Exists(Program.filename))
            {
                // File.Decrypt(Program.filename);
                StreamReader FileR = new StreamReader(Program.filename);

                string[] file = FileR.ReadLine().Split(' ');
                maxName = file[0];
                maxScore = Convert.ToInt32(file[1]);

                FileR.Close();
                // File.Encrypt(Program.filename);
            }
            CreaOggettiAsync();

            timeMove.Start();
            stopwatch.Start();
        }

        /// <summary>
        /// Metodo che aggiorna lo stato del gioco
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timeMove_Tick(object sender, EventArgs e)
        {
            lblPunteggio.Text = Program.score.ToString();
            lblMassimoPunteggio.Text = maxName + " " + maxScore.ToString();

            // muove la nave
            if(creati)
                moveShip();

            stampaVita(true);

            Control[] giocatore = this.Controls.Find("pictSpaceship", true);
            Control[] alieni = this.Controls.Find("alien", true);
            Control[] ostacoli = this.Controls.Find("obstacle", true);

            if (alieni.Length > 0)
            {
                bool boolAlieno = false;
                // ciclo principale per il movimento e le intersezioni del fuoco del player
                for (i = (byte)listaFuoco.Count; i > 0; i--)
                {
                    bool boolOstacolo = false;

                    // testa se uno degli alieni viene colpito
                    for (j = (byte)alieni.Length; j > 0 && !boolAlieno; j--)
                        if (Colpito(listaFuoco[i - 1], alieni[j - 1]))
                        {
                            // se il fuoco lo colpisce aumenta lo score
                            Program.score++;
                            if (Program.score > maxScore)
                            {
                                maxName = "---";
                                maxScore = Program.score;

                                // Program.max = true;
                            }

                            // elimina tutti gli oggetti che collidono
                            eliminaOggetto(alieni[j - 1]);
                            eliminaOggetto(listaFuoco[i - 1]);

                            aliens.Remove(alieni[j - 1]);
                            listaFuoco.Remove(listaFuoco[i - 1]);

                            boolAlieno = true;
                        }
                    // ciclo su tutti gli ostacoli
                    for (int j = ostacoli.Length; j > 0 && !boolOstacolo && !boolAlieno; j--)
                        if (Colpito(listaFuoco[i - 1], ostacoli[j - 1]))
                        {
                            // testa se e' l'ostacolo di destra o di sinistra
                            if (ostacoli[j - 1].Location.X < this.Width)
                            {
                                // cerca per ogni "pixel" di ostacolo
                                for (byte k = altOb; k > 0; k--)
                                    for (byte x = lung0[k]; x > 0; x--)
                                        if (obstacle[k - 1][x - 1].Bounds == ostacoli[j - 1].Bounds)
                                        {
                                            obstacle[k - 1].Remove((PictureBox)ostacoli[j - 1]);
                                            lung0[x - 1]--;

                                            break;
                                        }
                            }
                            else
                            {
                                for (byte k = altOb; k > 0; k--)
                                    for (byte x = lung1[k]; x > 0; x--)
                                        if (obstacle1[k - 1][x - 1].Bounds == ostacoli[j - 1].Bounds)
                                        {
                                            obstacle1[k].Remove((PictureBox)ostacoli[j - 1]);
                                            lung1[x - 1]--;

                                            break;
                                        }
                            }
                            // elimina tutti gli oggetti che collidono
                            eliminaOggetto(ostacoli[j - 1]);
                            eliminaOggetto(listaFuoco[i - 1]);

                            listaFuoco.Remove(listaFuoco[i - 1]);
                            boolOstacolo = true;
                        }
                    if (listaFuoco.Count > 0 && !(boolAlieno || boolOstacolo))
                    {
                        listaFuoco[i - 1].Top -= 15;

                        if (listaFuoco[i - 1] != null && listaFuoco[i - 1].Location.Y < 0)
                            eliminaOggetto(listaFuoco[i - 1]);
                    }

                    // per trillo <3 :-*
                    // break;
                }

                // per gestire l'errore 
                // della i: se troppo piccola o troppo grande
                byte index;

                //ciclo per il fuoco avversario
                for (i = (byte)listaFuocoNemico.Count; i > 0; i--)
                {
                    bool boolPlayer = false;
                    bool boolOstacolo = false;

                    if ((i - 1) > listaFuocoNemico.Count - 1)
                        index = Convert.ToByte(i - 2);
                    else if (listaFuocoNemico.Count == 0)
                        index = i;
                    else
                        index = Convert.ToByte(i - 1);

                    // cerca la collisioni con la navicella
                    if (Colpito(listaFuocoNemico[index], giocatore[0]) && !invincibile)
                    {
                        if (!invincibile)
                            life--;
                        invincibile = true;

                        if (life == 0)
                        {
                            fine();
                            Application.Exit();
                        }
                        stampaVita(false);

                        // invincibilità - respawn a intermittenza nave
                        intermittenza();

                        eliminaOggetto(listaFuocoNemico[index]);
                        listaFuocoNemico.Remove(listaFuocoNemico[index]);

                        boolPlayer = true;
                    }
                    for (int j = ostacoli.Length; j > 0 && !boolOstacolo && !boolPlayer; j--)
                    {
                        if (i > listaFuocoNemico.Count)
                            index = Convert.ToByte(i - 2);
                        else if (i < listaFuocoNemico.Count - 2)
                            index = i;
                        else
                            index = Convert.ToByte(i - 1);

                        if (Colpito(listaFuocoNemico[index], ostacoli[j - 1]))
                        {
                            // elimina tutti gli oggetti che collidono
                            eliminaOggetto(ostacoli[j - 1]);
                            eliminaOggetto(listaFuocoNemico[index]);

                            if (ostacoli[j - 1].Location.X < this.Width)
                            {
                                for (byte k = altOb; k > 0; k--)
                                    for (byte x = lungA0[k]; x > 0; x--)
                                        if (obstacle[k - 1][x - 1].Bounds == ostacoli[j - 1].Bounds)
                                        {
                                            obstacle[k - 1].Remove((PictureBox)ostacoli[j - 1]);
                                            lungA0[x - 1]--;

                                            break;
                                        }
                            }
                            else
                            {
                                for (byte k = altOb; k > 0; k--)
                                    for (byte x = lungA1[k]; x > 0; x--)
                                        if (obstacle1[k][x].Bounds == ostacoli[j - 1].Bounds)
                                        {
                                            obstacle1[k].Remove((PictureBox)ostacoli[j - 1]);
                                            lungA1[x - 1]--;

                                            break;
                                        }
                            }
                            listaFuocoNemico.Remove(listaFuocoNemico[index]);

                            boolOstacolo = true;
                        }
                    }                       
                    if (listaFuocoNemico.Count > 0 && !(boolOstacolo || boolPlayer))
                    {
                        listaFuocoNemico[index].Top += 15;

                        if (listaFuocoNemico[index] != null && listaFuocoNemico[index].Location.Y > this.Size.Height)
                            eliminaOggetto(listaFuocoNemico[index]);
                    }
                }
                if (stopwatch.ElapsedMilliseconds % rateFuoco == 0)
                {
                    // sceglie un avversario random e lo fa sparare
                    Control control = alieni[(byte)rand.Next(0, alieni.Length - 1)];
                    var fuocoNemico = new PictureBox
                    {
                        Name = "fuocoNemico",
                        Size = new Size(5, 14),
                        Location = new Point(control.Location.X + 15, control.Location.Y),
                        BackColor = Color.DarkGreen,
                        Visible = true,
                        Enabled = true
                    };

                    this.Controls.Add(fuocoNemico);
                    listaFuocoNemico.Add(fuocoNemico);
                }

                // controllo dell'alieno piu esterno a seconda della direzioneAlieni
                Control alienoBordo = alieni[0];
                int m = alieni[0].Location.X;

                // trova l'alieno al bordo
                for (i = 1; i < alieni.Length; i++)
                {
                    if (direzioneAlieni < 0)
                    {
                        if (alieni[i].Location.X < m)
                        {
                            m = alieni[i].Location.X;
                            alienoBordo = alieni[i];
                        }
                    }
                    else if (direzioneAlieni > 0)
                    {
                        if (alieni[i].Location.X > m)
                        {
                            m = alieni[i].Location.X;
                            alienoBordo = alieni[i];
                        }
                    }
                }

                // movimento degli alieni
                for (i = 0; i < alieni.Length; i++)
                    alieni[i].Left += (int)direzioneAlieni;

                // test se l'alieno al bordo ha colpito il bordo
                bool bordo = false;
                if (direzioneAlieni < 0)
                {
                    if (alienoBordo.Location.X <= 50)
                        bordo = true;
                }
                else if (direzioneAlieni > 0)
                {
                    if (alienoBordo.Location.X + 41 >= this.Width - 50)
                        bordo = true;
                }

                // se il bordo è stato colpito
                if (bordo)
                {
                    for (i = 0; i < alieni.Length; i++)
                        spostamento(alieni[i]);
                    direzioneAlieni = -direzioneAlieni;
                }
            }
            // entra se non ci sono alieni ma sono stati generati
            // cioè quando si è completato il livello
            else if(creati)
            {
                if(level < 5)
                {
                    level++;
                    rateFuoco -= 7;
                    if (direzioneAlieni > 0)
                        direzioneAlieni += 1;
                    else
                        direzioneAlieni -= 1;

                    DistruggiOggetti();
                    CreaOggettiAsync();
                }
                else
                    fine();
            }
        }
        
        private void intermittenza()
        {
            timeColpito.Start();
        }

        private void timeColpito_Tick(object sender, EventArgs e)
        {
            pictSpaceship.Visible = !pictSpaceship.Visible;
            nFlash++;
            
            if(nFlash == 10)
            {
                pictSpaceship.Visible = true;
                invincibile = false;
                nFlash = 0;

                timeColpito.Stop();
            }
        }

        private void fine()
        {
            timeMove.Stop();

            Hide();

            Form frmHighScore = new frmHighScore();
            frmHighScore.ShowDialog();

            timeMove.Start();
        }

        private void spostamento(Control alieno)
        {
            if (alieno.Location.Y + alieno.Size.Height < obstacle[0][0].Location.Y)
                alieno.Top += 20;
            else
            {
                timeMove.Stop();

                Hide();

                Form frmHighScore = new frmHighScore();
                frmHighScore.ShowDialog();

                timeMove.Start();
            }
        }

        private void eliminaOggetto(Control oggetto)
        {
            this.Controls.Remove(oggetto);
            oggetto.Dispose();
        }

        private void stampaVita(bool condizione)
        {
            Control[] vite = this.Controls.Find("life", true);

            if (condizione)
            {
                // per stampare la vita rimasta
                int cont = 0;
                for (i = 0; i < vite.Length; i++)
                {
                    if (cont < life)
                    {
                        vite[i].Visible = true;
                        cont++;
                    }
                }
            }
            else
                // "azzera" la vita graficamente
                for (i = 0; i < vite.Length; i++)
                    vite[i].Visible = false;
        }

        /// <summary>
        /// Metodo per testare se si è colpito il nemico o un ostacolo
        /// </summary>
        /// <param name="oggetto"></param>
        /// <param name="toHitObject"></param>
        /// <returns></returns>
        private bool Colpito(Control oggetto, Control toHitObject)
        {
            // se interseca -> true
            if (oggetto.Bounds.IntersectsWith(toHitObject.Bounds))
                return true;
            return false;
        }

        /********************************************
         * Vari metodi per il movimento della nave
         */
        private void moveShip()
        {
            if (_moveLeft)
                pictSpaceship.Left += -15;

            if (_moveRight)
                pictSpaceship.Left += 15;
        }
        private void frmSpaceInvaders_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                if (pictSpaceship.Location.X - 20 < 0)
                    _moveLeft = false;
                else
                    _moveLeft = true;
                _moveRight = false;
            }
            else if (e.KeyCode == Keys.D)
            {
                _moveLeft = false;
                if ((pictSpaceship.Location.X + pictSpaceship.Width + 25) > this.Size.Width)
                    _moveRight = false;
                else
                    _moveRight = true;
            }
        }
        private void frmSpaceInvaders_KeyUp(object sender, KeyEventArgs e)
        {
            _moveLeft = false;
            _moveRight = false;
        }

        /// <summary>
        /// Dopo il click di qualcosa sulla scena si genera un fuoco.
        /// Il click viene rallentato per evitare la possibilità di troppi proiettili a disposizione.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictAlien36_Click(object sender, EventArgs e)
        {
            if (click)
            {
                var fire = new PictureBox
                {
                    Name = "fire",
                    Size = new Size(5, 14),
                    Location = new Point(pictSpaceship.Location.X + 15, pictSpaceship.Location.Y),
                    BackColor = Color.Blue,
                    Visible = true
                };

                this.Controls.Add(fire);
                listaFuoco.Add(fire);

                click = false;
                waitClick(300);
            }
            else
                waitClick(100);
        }

        private async void waitClick(int tempo)
        {
            int nuovoThread = await Task<int>.Run(() =>
                {
                    Task.Delay(tempo);
                    click = true;
                    return 1;
                });
        }

        /// <summary>
        /// Fissa la label con il numero del livello a schermo.
        /// </summary>
        /// <param name="tempo"></param>
        private async void mostraLivello(int tempo)
        {
            var l = new Label
            {
                AutoSize = true,
                Name = "Level",
                Text = "Level " + level,
                Location = new Point(250, 338),
                BackColor = Color.White,
                ForeColor = Color.Black,
                Font = new Font("Courier New", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                Visible = true
            };
            l.BringToFront();

            Controls.Add(l);
            await Task.Delay(tempo);

            Thread.Sleep(tempo * 15);
            Controls.Remove(l);
        }

        /************************************************************************************
         *
         * Distrugge oggetti rimasti (in teoria solo ostacoli)
         *
         */
        private void DistruggiOggetti()
        {
            // Control[] alieni = this.Controls.Find("alien", true);
            Control[] ostacoli = this.Controls.Find("obstacle", true);
            Control[] fuoco = this.Controls.Find("fire", true);

            // eliminazione del fuoco e degli ostacoli
             for (int i = 0; i < fuoco.Length; i++)
                 this.Controls.Remove(fuoco[i]);
            for(int i = 0; i < ostacoli.Length; i++)
                this.Controls.Remove(ostacoli[i]);

            // cancellazione ulteriore dalle liste del fuoco
            // listaFuoco.Clear();
            // listaFuocoNemico.Clear();
        }

        /************************************************************************************
         * 
         * 
         * Creazione oggetti di gioco
         * 
         * 
         */
        private async void CreaOggettiAsync()
        {
            life = 3;
            creati = false;

            Form frmCaricamento = new frmCaricamento();
            frmCaricamento.Show();


            List<Control> oggetti = await Task<int>.Run(() =>
            {
                List<Control> controlli = new List<Control>();

                byte i, j;

                int cont = 0;
                int grPixel = 5;

                // creazione alieni
                x = 100;
                y = 110;
                for (i = (byte) 0; aliens.Count < nAlieni; i++)
                {
                    if (i % 7 == 0)
                    {
                        y += 50;
                        cont = 0;
                    }

                    var alien = new PictureBox
                    {
                        Name = "alien",
                        BackColor = Color.Transparent,
                        Image = global::_20180407_SpaceInvaders.Properties.Resources.alien,
                        Location = new Point(x + cont * 100, y),
                        Size = new Size(41, 28),
                        SizeMode = PictureBoxSizeMode.StretchImage
                    };
                    alien.Click += new EventHandler(PictAlien36_Click);

                    cont++;

                    aliens.Add(alien);
                    controlli.Add(alien);

                    Program.progress++;
                }

                // creazione ostacoli
                x = 150;
                y = 450;

                for (i = 0; i < altOb; i++)
                {
                    obstacle.Add(new List<PictureBox>(lungOb));
                    // obstacle[i] = new List<PictureBox>(lungOb);
                    for (j = 0; j < lungOb; j++)
                    {
                        // crea un particolare di ostacolo, con tutte le proprietà
                        var ostacolo = new PictureBox
                        {
                            Name = "obstacle",
                            BackColor = Color.Red,
                            Location = new Point(x + j * grPixel, y),
                            Size = new Size(grPixel, grPixel),
                            SizeMode = PictureBoxSizeMode.StretchImage
                        };
                        ostacolo.Click += new EventHandler(PictAlien36_Click);

                        obstacle[i].Add(ostacolo);
                        controlli.Add(ostacolo);

                        Program.progress++;
                    }
                    y += 5;
                }

                // creazione ostacoli
                x = 575;
                y = 450;

                for (i = 0; i < altOb; i++)
                {
                    obstacle1.Add(new List<PictureBox>(lungOb));
                    for (j = 0; j < lungOb; j++)
                    {
                        var ostacolo1 = new PictureBox
                        {
                            Name = "obstacle",
                            BackColor = Color.Red,
                            Location = new Point(x + j * grPixel, y),
                            Size = new Size(grPixel, grPixel),
                            SizeMode = PictureBoxSizeMode.StretchImage
                        };
                        ostacolo1.Click += new EventHandler(PictAlien36_Click);

                        obstacle1[i].Add(ostacolo1);
                        controlli.Add(ostacolo1);

                        Program.progress++;
                    }
                    y += 5;
                }
                
                //creazione vite 
                x = 650;
                y = 9;

                for(i = 0; i < life; i++)
                {
                    var vita = new PictureBox
                    {
                        Name = "life",
                        BackColor = Color.Yellow,
                        Location = new Point(x + i * 50, y),
                        Size = new Size(32, 32),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Visible = false
                    };
                    vita.Click += new EventHandler(PictAlien36_Click);

                    controlli.Add(vita);
                    Program.progress++;
                }

                return controlli;
            });

            for (int i = 0; i < oggetti.Count; i++)
                this.Controls.Add(oggetti[i]);

            mostraLivello(100);

            creati = true;
        }
    }
}