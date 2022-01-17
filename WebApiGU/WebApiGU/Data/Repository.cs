using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using WebApiGU.Models;

namespace WebApiGU.Data
{
    public class Repository : IRepository
    {
        public List<GetAllKupce> AllKupac()
        {
            List<GetAllKupce> kupci = new List<GetAllKupce>();
            using (var con = new NpgsqlConnection("Server=localhost;User Id=postgres; Password=lozinka5;Database=Galerija_umjetnina;"))
            {
                con.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM \"Kupac\"", con))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            GetAllKupce p = new GetAllKupce
                            {
                                idKupac = (int)reader["idKupac"],
                                Ime = (string)reader["Ime"],
                                Prezime = (string)reader["Prezime"],
                                Broj_telefona= (string)reader["Broj_telefona"],
                                Email = (string)reader["Email"],
                                Adresa = (string)reader["Adresa"]
                            };
                            kupci.Add(p);
                        }
                    }
                }
                return kupci;
            }
        }

        public CreateKupacResponse CreateKupac(CreateKupacRequest Kupac)
        {
            CreateKupacResponse o = new CreateKupacResponse();
            using (var con = new NpgsqlConnection("Server=localhost;User Id=postgres; Password=lozinka5;Database=Galerija_umjetnina;"))
            {
                con.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("INSERT INTO  \"Kupac\" VALUES (default, @Ime, @Prezime,@Broj_telefona, @Adresa, @Email)", con))
                {
                    command.Parameters.AddWithValue("@Ime", Kupac.Ime);
                    command.Parameters.AddWithValue("@Prezime", Kupac.Prezime);
                    command.Parameters.AddWithValue("@Broj_telefona", Kupac.Broj_telefona);
                    command.Parameters.AddWithValue("@Adresa", Kupac.Adresa);
                    command.Parameters.AddWithValue("@Email", Kupac.Email);

                    int i = command.ExecuteNonQuery();
                    con.Close();

                    if (i >= 1)
                    {
                        o.Message = true;
                    }
                    else
                    {
                        o.Message = false;
                    }
                    return o;
                }
            }
        }

        public UpdateKupacResponse UpdateKupac(UpdateKupacRequest Kupac)
        {
            UpdateKupacResponse u = new UpdateKupacResponse();
            using (var con = new NpgsqlConnection("Server=localhost;User Id=postgres; Password=lozinka5;Database=Galerija_umjetnina;"))
            {
                con.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("UPDATE \"Kupac\" SET \"Ime\" = @Ime, \"Prezime\" = @Prezime, \"Broj_telefona\" = @Broj_telefona, \"Adresa\" = @Adresa, \"Email\" = @Email WHERE \"idKupac\" = @idKupac", con))
                {
                    command.Parameters.AddWithValue("@idKupac", Kupac.idKupac);
                    command.Parameters.AddWithValue("@Ime", Kupac.Ime);
                    command.Parameters.AddWithValue("@Prezime", Kupac.Prezime);
                    command.Parameters.AddWithValue("@Broj_telefona", Kupac.Broj_telefona);
                    command.Parameters.AddWithValue("@Adresa", Kupac.Adresa);
                    command.Parameters.AddWithValue("@Email", Kupac.Email);

                    int i = command.ExecuteNonQuery();
                    con.Close();
                    if (i >= 1)
                    {
                        u.Message = true;
                    }
                    else
                    {
                        u.Message = false;
                    }
                    return u;
                }
            }
        }

        public DeleteKupacResponse DeleteKupacById(int idKupac)
        {
            DeleteKupacResponse u = new DeleteKupacResponse();
            using (var con = new NpgsqlConnection("Server=localhost;User Id=postgres; Password=lozinka5;Database=Galerija_umjetnina;"))
            {
                con.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("DELETE FROM \"Kupac\" WHERE \"idKupac\" = " + idKupac, con))
                {
                    int i = command.ExecuteNonQuery();
                    con.Close();

                    if (i >= 1)
                    {
                        u.Message = true;
                    }
                    else
                    {
                        u.Message = false;
                    }
                    return u;
                }
            }
        }
        public GetKupacById GetKupac(int idKupac)
        {
            GetKupacById kupac = new GetKupacById();
            using (var con = new NpgsqlConnection("Server=localhost;User Id=postgres; Password=lozinka5;Database=Galerija_umjetnina;"))
            {
                con.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM \"Kupac\" WHERE \"idKupac\" = " + idKupac, con))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            kupac.idKupac = (int)reader["idKupac"];
                            kupac.Ime = (string)reader["Ime"];
                            kupac.Prezime = (string)reader["Prezime"];
                            kupac.Broj_telefona = (string)reader["Broj_telefona"];
                            kupac.Email = (string)reader["Email"];
                            kupac.Adresa = (string)reader["Adresa"];
                        }
                        con.Close();
                        return kupac;
                    }
                }
            }
        }

        public CreateIzlozbaResponse CreateIzlozba(CreateIzlozbaRequest Izlozba)
        {
            CreateIzlozbaResponse o = new CreateIzlozbaResponse();
            using (var con = new NpgsqlConnection("Server=localhost;User Id=postgres; Password=lozinka5;Database=Galerija_umjetnina;"))
            {
                con.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("INSERT INTO  \"Izložba\" VALUES (default, @Naziv,@Datum_početka, @Datum_završetka, @Prostor_održavanja)", con))
                {
                    command.Parameters.AddWithValue("@Naziv", Izlozba.Naziv);
                    command.Parameters.AddWithValue("@Prostor_održavanja", Izlozba.Prostor_održavanja);
                    command.Parameters.AddWithValue("@Datum_početka", Izlozba.Datum_početka);
                    command.Parameters.AddWithValue("@Datum_završetka", Izlozba.Datum_završetka);
                   

                    int i = command.ExecuteNonQuery();
                    con.Close();

                    if (i >= 1)
                    {
                        o.Message = true;
                    }
                    else
                    {
                        o.Message = false;
                    }
                    return o;
                }
            }
        }

        public List<GetAllIzlozbe> AllIzlozba()
        {
            List<GetAllIzlozbe> izlozbe = new List<GetAllIzlozbe>();
            using (var con = new NpgsqlConnection("Server=localhost;User Id=postgres; Password=lozinka5;Database=Galerija_umjetnina;"))
            {
                con.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM \"Izložba\"", con))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            GetAllIzlozbe p = new GetAllIzlozbe
                            {
                                idIzložba = (int)reader["idIzložba"],
                                Naziv = (string)reader["Naziv"],
                                Prostor_održavanja = (string)reader["Prostor_održavanja"],
                                Datum_početka = (DateTime)reader["Datum_početka"],
                                Datum_završetka = (DateTime)reader["Datum_završetka"]
                            };
                            izlozbe.Add(p);
                        }
                    }
                }
                return izlozbe;
            }
        }


        public DeleteIzlozbaResponse DeleteIzlozbaById(int idIzložba)
        {
            DeleteIzlozbaResponse u = new DeleteIzlozbaResponse();
            using (var con = new NpgsqlConnection("Server=localhost;User Id=postgres; Password=lozinka5;Database=Galerija_umjetnina;"))
            {
                con.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("DELETE FROM \"Izložba\" WHERE \"idIzložba\" = " + idIzložba, con))
                {
                    int i = command.ExecuteNonQuery();
                    con.Close();

                    if (i >= 1)
                    {
                        u.Message = true;
                    }
                    else
                    {
                        u.Message = false;
                    }
                    return u;
                }
            }
        }

        public GetIzlozbaById GetIzlozba(int idIzložba)
        {
            GetIzlozbaById izlozba = new GetIzlozbaById();
            using (var con = new NpgsqlConnection("Server=localhost;User Id=postgres; Password=lozinka5;Database=Galerija_umjetnina;"))
            {
                con.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM \"Izložba\" WHERE \"idIzložba\" = " + idIzložba, con))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            izlozba.idIzložba = (int)reader["idIzložba"];
                            izlozba.Naziv = (string)reader["Naziv"];
                            izlozba.Prostor_održavanja = (string)reader["Prostor_održavanja"];
                            izlozba.Datum_početka = (DateTime)reader["Datum_početka"];
                            izlozba.Datum_završetka = (DateTime)reader["Datum_završetka"];
                            
                        }
                        con.Close();
                        return izlozba;
                    }
                }
            }
        }

        public UpdateIzlozbaResponse UpdateIzlozba(UpdateIzlozbaRequest Izlozba)
        {
            UpdateIzlozbaResponse u = new UpdateIzlozbaResponse();
            using (var con = new NpgsqlConnection("Server=localhost;User Id=postgres; Password=lozinka5;Database=Galerija_umjetnina;"))
            {
                con.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("UPDATE \"Izložba\" SET \"Naziv\" = @Naziv, \"Prostor_održavanja\" = @Prostor_održavanja, \"Datum_početka\" = @Datum_početka, \"Datum_završetka\" = @Datum_završetka WHERE \"idIzložba\" = @idIzložba", con))
                {
                    command.Parameters.AddWithValue("@idIzložba", Izlozba.idIzložba);
                    command.Parameters.AddWithValue("@Naziv", Izlozba.Naziv);
                    command.Parameters.AddWithValue("@Prostor_održavanja", Izlozba.Prostor_održavanja);
                    command.Parameters.AddWithValue("@Datum_početka", Izlozba.Datum_početka);
                    command.Parameters.AddWithValue("@Datum_završetka", Izlozba.Datum_završetka);

                    int i = command.ExecuteNonQuery();
                    con.Close();
                    if (i >= 1)
                    {
                        u.Message = true;
                    }
                    else
                    {
                        u.Message = false;
                    }
                    return u;
                }
            }
        }

        public List<GetAllUmjetnike> AllUmjetnik()
        {
            List<GetAllUmjetnike> umjetnici = new List<GetAllUmjetnike>();
            using (var con = new NpgsqlConnection("Server=localhost;User Id=postgres; Password=lozinka5;Database=Galerija_umjetnina;"))
            {
                con.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM \"Umjetnik\"", con))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            GetAllUmjetnike p = new GetAllUmjetnike
                            {
                                idUmjetnik = (int)reader["idUmjetnik"],
                                Ime = (string)reader["Ime"],
                                Prezime = (string)reader["Prezime"],
                                Datum_rođenja = (DateTime)reader["Datum_rođenja"],
                                idMjesto = (int)reader["idMjesto"]
                            };
                            umjetnici.Add(p);
                        }
                    }
                }
                return umjetnici;
            }
        }

        public CreateUmjetnikResponse CreateUmjetnik(CreateUmjetnikRequest Umjetnik)
        {
            CreateUmjetnikResponse o = new CreateUmjetnikResponse();
            using (var con = new NpgsqlConnection("Server=localhost;User Id=postgres; Password=lozinka5;Database=Galerija_umjetnina;"))
            {
                con.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("INSERT INTO  \"Umjetnik\" VALUES (default, @Ime, @Prezime,@Datum_rođenja, @idMjesto)", con))
                {
                    command.Parameters.AddWithValue("@Ime", Umjetnik.Ime);
                    command.Parameters.AddWithValue("@Prezime", Umjetnik.Prezime);
                    command.Parameters.AddWithValue("@Datum_rođenja", Umjetnik.Datum_rođenja);
                    command.Parameters.AddWithValue("@idMjesto", Umjetnik.idMjesto);
                    

                    int i = command.ExecuteNonQuery();
                    con.Close();

                    if (i >= 1)
                    {
                        o.Message = true;
                    }
                    else
                    {
                        o.Message = false;
                    }
                    return o;
                }
            }
        }

        public UpdateUmjetnikResponse UpdateUmjetnik(UpdateUmjetnikRequest Umjetnik)
        {
            UpdateUmjetnikResponse u = new UpdateUmjetnikResponse();
            using (var con = new NpgsqlConnection("Server=localhost;User Id=postgres; Password=lozinka5;Database=Galerija_umjetnina;"))
            {
                con.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("UPDATE \"Umjetnik\" SET \"Ime\" = @Ime, \"Prezime\" = @Prezime, \"Datum_rođenja\" = @Datum_rođenja, \"idMjesto\" = @idMjesto WHERE \"idUmjetnik\" = @idUmjetnik", con))
                {
                    command.Parameters.AddWithValue("@idUmjetnik", Umjetnik.idUmjetnik);
                    command.Parameters.AddWithValue("@Ime", Umjetnik.Ime);
                    command.Parameters.AddWithValue("@Prezime", Umjetnik.Prezime);
                    command.Parameters.AddWithValue("@Datum_rođenja", Umjetnik.Datum_rođenja);
                    command.Parameters.AddWithValue("@idMjesto", Umjetnik.idMjesto);

                    int i = command.ExecuteNonQuery();
                    con.Close();
                    if (i >= 1)
                    {
                        u.Message = true;
                    }
                    else
                    {
                        u.Message = false;
                    }
                    return u;
                }
            }
           
        }
        public DeleteUmjetnikResponse DeleteUmjetnikById(int idUmjetnik)
        {
            DeleteUmjetnikResponse u = new DeleteUmjetnikResponse();
            using (var con = new NpgsqlConnection("Server=localhost;User Id=postgres; Password=lozinka5;Database=Galerija_umjetnina;"))
            {
                con.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("DELETE FROM \"Umjetnik\" WHERE \"idUmjetnik\" = " + idUmjetnik, con))
                {
                    int i = command.ExecuteNonQuery();
                    con.Close();

                    if (i >= 1)
                    {
                        u.Message = true;
                    }
                    else
                    {
                        u.Message = false;
                    }
                    return u;
                }
            }
        }
        public GetUmjetnikById GetUmjetnik(int idUmjetnik)
        {
            GetUmjetnikById umjetnik = new GetUmjetnikById();
            using (var con = new NpgsqlConnection("Server=localhost;User Id=postgres; Password=lozinka5;Database=Galerija_umjetnina;"))
            {
                con.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM \"Umjetnik\" WHERE \"idUmjetnik\" = " + idUmjetnik, con))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            umjetnik.idUmjetnik = (int)reader["idUmjetnik"];
                            umjetnik.Ime = (string)reader["Ime"];
                            umjetnik.Prezime = (string)reader["Prezime"];
                            umjetnik.Datum_rođenja= (DateTime)reader["Datum_rođenja"];
                            umjetnik.idMjesto = (int)reader["idMjesto"];

                        }
                        con.Close();
                        return umjetnik;
                    }
                }
            }
        }
        public List<GetListuMjestaPoNazivu> AllMjesta()
        {
            List<GetListuMjestaPoNazivu> mjesta = new List<GetListuMjestaPoNazivu>();
            using (var con = new NpgsqlConnection("Server=localhost;User Id=postgres; Password=lozinka5;Database=Galerija_umjetnina;"))
            {
                con.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT \"idMjesto\" ,\"Naziv\" FROM \"Mjesto\" ", con))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            GetListuMjestaPoNazivu p = new GetListuMjestaPoNazivu
                            {
                                idMjesto = (int)reader["idMjesto"],
                                Naziv = (string)reader["Naziv"]
                            };
                            mjesta.Add(p);
                        }
                    }
                }
                return mjesta;
            }
        }

        public List<GetAllTipove> AllTip()
        {
            List<GetAllTipove> tipovi = new List<GetAllTipove>();
            using (var con = new NpgsqlConnection("Server=localhost;User Id=postgres; Password=lozinka5;Database=Galerija_umjetnina;"))
            {
                con.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM \"Tip_umjetnine\"", con))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            GetAllTipove p = new GetAllTipove
                            {
                                idTip = (int)reader["idTip"],
                                Naziv = (string)reader["Naziv"],
                                Opis = (string)reader["Opis"],
                                
                            };
                            tipovi.Add(p);
                        }
                    }
                }
                return tipovi;
            }
        }
        public CreateTipResponse CreateTip(CreateTipRequest Tip)
        {
            CreateTipResponse o = new CreateTipResponse();
            using (var con = new NpgsqlConnection("Server=localhost;User Id=postgres; Password=lozinka5;Database=Galerija_umjetnina;"))
            {
                con.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("INSERT INTO  \"Tip_umjetnine\" VALUES (default, @Naziv,@Opis)", con))
                {
                    command.Parameters.AddWithValue("@Naziv", Tip.Naziv);
                    command.Parameters.AddWithValue("@Opis", Tip.Opis);
                    


                    int i = command.ExecuteNonQuery();
                    con.Close();

                    if (i >= 1)
                    {
                        o.Message = true;
                    }
                    else
                    {
                        o.Message = false;
                    }
                    return o;
                }
            }
        }
        public UpdateTipResponse UpdateTip(UpdateTipRequest Tip)
        {
            UpdateTipResponse u = new UpdateTipResponse();
            using (var con = new NpgsqlConnection("Server=localhost;User Id=postgres; Password=lozinka5;Database=Galerija_umjetnina;"))
            {
                con.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("UPDATE \"Tip_umjetnine\" SET \"Naziv\" = @Naziv, \"Opis\" = @Opis WHERE \"idTip\" = @idTip", con))
                {
                    command.Parameters.AddWithValue("@idTip", Tip.idTip);
                    command.Parameters.AddWithValue("@Naziv", Tip.Naziv);
                    command.Parameters.AddWithValue("@Opis", Tip.Opis);
                  

                    int i = command.ExecuteNonQuery();
                    con.Close();
                    if (i >= 1)
                    {
                        u.Message = true;
                    }
                    else
                    {
                        u.Message = false;
                    }
                    return u;
                }
            }
        }
        public DeleteTipResponse DeleteTipById(int idTip)
        {
            DeleteTipResponse u = new DeleteTipResponse();
            using (var con = new NpgsqlConnection("Server=localhost;User Id=postgres; Password=lozinka5;Database=Galerija_umjetnina;"))
            {
                con.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("DELETE FROM \"Tip_umjetnine\" WHERE \"idTip\" = " + idTip, con))
                {
                    int i = command.ExecuteNonQuery();
                    con.Close();

                    if (i >= 1)
                    {
                        u.Message = true;
                    }
                    else
                    {
                        u.Message = false;
                    }
                    return u;
                }
            }
        }
        public GetTipById GetTip(int idTip)
        {
            GetTipById tip = new GetTipById();
            using (var con = new NpgsqlConnection("Server=localhost;User Id=postgres; Password=lozinka5;Database=Galerija_umjetnina;"))
            {
                con.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM \"Tip_umjetnine\" WHERE \"idTip\" = " + idTip, con))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tip.idTip = (int)reader["idTip"];
                            tip.Naziv = (string)reader["Naziv"];
                            tip.Opis = (string)reader["Opis"];
                            

                        }
                        con.Close();
                        return tip;
                    }
                }
            }
        }
        public List<GetAllUmjetnine> AllUmjetnina()
        {
            List<GetAllUmjetnine> umjetnine = new List<GetAllUmjetnine>();
            using (var con = new NpgsqlConnection("Server=localhost;User Id=postgres; Password=lozinka5;Database=Galerija_umjetnina;"))
            {
                con.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM \"Umjetnina\"", con))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            GetAllUmjetnine p = new GetAllUmjetnine
                            {
                                idUmjetnina = (int)reader["idUmjetnina"],
                                Naziv = (string)reader["Naziv"],
                                Opis = (string)reader["Opis"],
                                Godina = (int)reader["Godina"],
                                Slika = (string)reader["Slika"],
                                Dimenzije = (string)reader["Dimenzije"],
                                Cijena = (string)reader["Cijena"],
                                idTip = (int)reader["idTip"],
                                idUmjetnik = (int)reader["idUmjetnik"],


                        };
                            umjetnine.Add(p);
                        }
                    }
                }
                return umjetnine;
            }
        }
        public CreateUmjetninaResponse CreateUmjetnina(CreateUmjetninaRequest Umjetnina)
        {
            CreateUmjetninaResponse o = new CreateUmjetninaResponse();
            using (var con = new NpgsqlConnection("Server=localhost;User Id=postgres; Password=lozinka5;Database=Galerija_umjetnina;"))
            {
                con.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("INSERT INTO  \"Umjetnina\" VALUES (default, @Naziv,@Godina,@Cijena,@Slika,@Opis,@Dimenzije,@idUmjetnik,@idTip)", con))
                {
                    command.Parameters.AddWithValue("@Naziv", Umjetnina.Naziv);
                    command.Parameters.AddWithValue("@Opis", Umjetnina.Opis);
                    command.Parameters.AddWithValue("@Cijena", Umjetnina.Cijena);
                    command.Parameters.AddWithValue("@Slika", Umjetnina.Slika);
                    command.Parameters.AddWithValue("@Godina", Umjetnina.Godina);
                    command.Parameters.AddWithValue("@Dimenzije", Umjetnina.Dimenzije);
                    command.Parameters.AddWithValue("@idTip", Umjetnina.idTip);
                    command.Parameters.AddWithValue("@idUmjetnik", Umjetnina.idUmjetnik);





                    int i = command.ExecuteNonQuery();
                    con.Close();

                    if (i >= 1)
                    {
                        o.Message = true;
                    }
                    else
                    {
                        o.Message = false;
                    }
                    return o;
                }
            }
        }
        public UpdateUmjetninaResponse UpdateUmjetnina(UpdateUmjetninaRequest Umjetnina)
        {
            UpdateUmjetninaResponse u = new UpdateUmjetninaResponse();
            using (var con = new NpgsqlConnection("Server=localhost;User Id=postgres; Password=lozinka5;Database=Galerija_umjetnina;"))
            {
                con.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("UPDATE \"Umjetnina\" SET \"Naziv\" = @Naziv, \"Opis\" = @Opis,\"Cijena\" = @Cijena,\"Slika\" = @Slika,\"Godina\" = @Godina,\"Dimenzije\" = @Dimenzije,\"idTip\" = @idTip,\"idUmjetnik\" = @idUmjetnik WHERE \"idUmjetnina\" = @idUmjetnina", con))
                {
                    command.Parameters.AddWithValue("@idUmjetnina",Umjetnina.idUmjetnina);
                    command.Parameters.AddWithValue("@Naziv", Umjetnina.Naziv);
                    command.Parameters.AddWithValue("@Opis", Umjetnina.Opis);
                    command.Parameters.AddWithValue("@Cijena", Umjetnina.Cijena);
                    command.Parameters.AddWithValue("@Slika", Umjetnina.Slika);
                    command.Parameters.AddWithValue("@Godina", Umjetnina.Godina);
                    command.Parameters.AddWithValue("@Dimenzije", Umjetnina.Dimenzije);
                    command.Parameters.AddWithValue("@idTip", Umjetnina.idTip);
                    command.Parameters.AddWithValue("@idUmjetnik", Umjetnina.idUmjetnik);


                    int i = command.ExecuteNonQuery();
                    con.Close();
                    if (i >= 1)
                    {
                        u.Message = true;
                    }
                    else
                    {
                        u.Message = false;
                    }
                    return u;
                }
            }
        }

        public DeleteUmjetninaResponse DeleteUmjetninaById(int idUmjetnina)
        {
            DeleteUmjetninaResponse u = new DeleteUmjetninaResponse();
            using (var con = new NpgsqlConnection("Server=localhost;User Id=postgres; Password=lozinka5;Database=Galerija_umjetnina;"))
            {
                con.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("DELETE FROM \"Umjetnina\" WHERE \"idUmjetnina\" = " + idUmjetnina, con))
                {
                    int i = command.ExecuteNonQuery();
                    con.Close();

                    if (i >= 1)
                    {
                        u.Message = true;
                    }
                    else
                    {
                        u.Message = false;
                    }
                    return u;
                }
            }
        }
        public GetUmjetninaById GetUmjetnina(int idUmjetnina)
        {
            GetUmjetninaById umjetnina = new GetUmjetninaById();
            using (var con = new NpgsqlConnection("Server=localhost;User Id=postgres; Password=lozinka5;Database=Galerija_umjetnina;"))
            {
                con.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM \"Umjetnina\" WHERE \"idUmjetnina\" = " + idUmjetnina, con))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            umjetnina.idUmjetnina = (int)reader["idUmjetnina"];
                            umjetnina.Naziv = (string)reader["Naziv"];
                            umjetnina.Opis = (string)reader["Opis"];
                            umjetnina.Cijena = (string)reader["Cijena"];
                            umjetnina.Slika = (string)reader["Slika"];
                            umjetnina.Godina = (int)reader["Godina"];
                            umjetnina.Dimenzije = (string)reader["Dimenzije"];
                            umjetnina.idTip = (int)reader["idTip"];
                            umjetnina.idUmjetnik = (int)reader["idUmjetnik"];


                        }
                        con.Close();
                        return umjetnina;
                    }
                }
            }
        }
        public List<GetListuTipovaPoNazivu> AllTipova()
        {
            List<GetListuTipovaPoNazivu> tipovi = new List<GetListuTipovaPoNazivu>();
            using (var con = new NpgsqlConnection("Server=localhost;User Id=postgres; Password=lozinka5;Database=Galerija_umjetnina;"))
            {
                con.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT \"idTip\" ,\"Naziv\" FROM \"Tip_umjetnine\" ", con))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            GetListuTipovaPoNazivu p = new GetListuTipovaPoNazivu
                            {
                                idTip = (int)reader["idTip"],
                                Naziv = (string)reader["Naziv"]
                            };
                            tipovi.Add(p);
                        }
                    }
                }
                return tipovi;
            }
        }

        public List<GetListuUmjetnikaPoNazivu> AllUmjetnika()
        {
            List<GetListuUmjetnikaPoNazivu> umjetnici = new List<GetListuUmjetnikaPoNazivu>();
            using (var con = new NpgsqlConnection("Server=localhost;User Id=postgres; Password=lozinka5;Database=Galerija_umjetnina;"))
            {
                con.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT \"idUmjetnik\" ,concat_ws(' ',\"Ime\",\"Prezime\")AS Naziv FROM \"Umjetnik\" ", con))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            GetListuUmjetnikaPoNazivu p = new GetListuUmjetnikaPoNazivu
                            {
                                idUmjetnik = (int)reader["idUmjetnik"],
                                Naziv = (string)reader["Naziv"]
                            };
                            umjetnici.Add(p);
                        }
                    }
                }
                return umjetnici;
            }
        }

    }
}