using Microsoft.EntityFrameworkCore;
using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PointOfSale.Controllers
{
    public class ReporteController
    {
        public bool Delete(Reporte o)
        {
            try
            {
                using (var db = new DymContext())
                {

                    db.Remove(o);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Algo salio mal @ " + GetType().Name + "\n" + ex.ToString());
            }
            return false;
        }

        public bool Delete(int Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    var temp = db.Reporte.FirstOrDefault(x => x.ReporteId == Id);
                    if (temp != null)
                    {
                        db.Remove(temp);
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Algo salio mal @ " + GetType().Name + "\n" + ex.ToString());
            }
            return false;
        }

        public bool InsertOne(Reporte o)
        {
            try
            {
                using (var db = new DymContext())
                {
                    db.Add(o);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Algo salio mal @ " + GetType().Name + "\n" + ex.ToString());
            }
            return false;
        }

        public bool InsertRange(List<Reporte> lista)
        {
            try
            {
                using (var db = new DymContext())
                {
                    db.AddRange(lista);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Algo salio mal @ " + GetType().Name + "\n" + ex.ToString());
            }
            return false;
        }

        public List<Reporte> SelectAll()
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.Reporte.ToList();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Algo salio mal @ " + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }
        public List<Reporte> FiltrarVsNombre(string s)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.Reporte.Where(x => EF.Functions.Like(x.Nombre, "%" + s.Trim() + "%")).ToList();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Algo salio mal @ " + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }

        public List<Reporte> SelectMany(int cantidad)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.Reporte.Take(cantidad).ToList();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Algo salio mal @ " + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }

        public Reporte SelectOne(int Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.Reporte.FirstOrDefault(x => x.ReporteId == Id);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Algo salio mal @ " + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }
        public Reporte SelectOneByName(string nombre)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.Reporte.FirstOrDefault(x => x.Nombre.Equals(nombre.Trim()));
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Algo salio mal @ " + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }

        public bool Update(Reporte o)
        {
            try
            {
                using (var db = new DymContext())
                {
                    db.Entry(o).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Algo salio mal @ " + GetType().Name + "\n" + ex.ToString());
            }
            return false;
        }

        public string Serializar(string Sql, List<Parametro> parametros = null)
        {
            if (parametros != null)
            {
                foreach (var p in parametros)
                {
                    Sql = Sql.Replace(p.Clave, p.Valor);
                }
            }
            return Sql;
        }
        public List<Parametro> DeSerializar(string Sql)
        {
            List<Parametro> keyValues = new List<Parametro>();

            var output = String.Join(",", Regex.Matches(Sql, @"\[(.+?)\]")
                                                .Cast<Match>()
                                                .Select(m => m.Groups[1].Value));
            string[] words;

            if (!output.Equals(""))
                words = output.Split(',');
            else
                return keyValues;

            foreach (var word in words)
            {
                var p = new Parametro();
                p.Clave = "[" + word + "]";
                p.Valor = "";

                keyValues.Add(p);
            }

            return keyValues;
        }


        public string PreparedStatement(string Sql, string p1, string v1, string p2 = "", string v2 = "", string p3 = "", string v3 = "", string p4 = "", string v4 = "", string p5 = "", string v5 = "", string p6 = "", string v6 = "", string p7 = "", string v7 = "", string p8 = "", string v8 = "", string p9 = "", string v9 = "", string p10 = "", string v10 = "")
        {
            if (Sql.Length == 0)
            {
                System.Windows.Forms.MessageBox.Show("Error al preparar el Statement");
                return "";
            }
            if (p1.Trim().Length > 0 && v1.Trim().Length > 0)
                Sql = Sql.Replace(p1, v1);

            if (p2.Trim().Length > 0 && v2.Trim().Length > 0)
                Sql = Sql.Replace(p2, v2);

            if (p3.Trim().Length > 0 && v3.Trim().Length > 0)
                Sql = Sql.Replace(p3, v3);

            if (p4.Trim().Length > 0 && v4.Trim().Length > 0)
                Sql = Sql.Replace(p4, v4);

            if (p5.Trim().Length > 0 && v5.Trim().Length > 0)
                Sql = Sql.Replace(p5, v5);

            if (p6.Trim().Length > 0 && v6.Trim().Length > 0)
                Sql = Sql.Replace(p6, v6);

            if (p7.Trim().Length > 0 && v7.Trim().Length > 0)
                Sql = Sql.Replace(p7, v7);

            if (p8.Trim().Length > 0 && v8.Trim().Length > 0)
                Sql = Sql.Replace(p8, v8);

            if (p9.Trim().Length > 0 && v9.Trim().Length > 0)
                Sql = Sql.Replace(p9, v9);

            if (p10.Trim().Length > 0 && v10.Trim().Length > 0)
                Sql = Sql.Replace(p10, v10);

            return Sql;
        }
        public string GeneraSecuencia()
        {
            return Guid.NewGuid().ToString();
        }

        public DataSet GetDataSet(string SQL)
        {
            try
            {
                using (var db = new DymContext())
                {
                    SqlConnection conn = db.Database.GetDbConnection() as SqlConnection;
                    SqlDataAdapter da = new SqlDataAdapter();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = SQL;
                    da.SelectCommand = cmd;
                    DataSet ds = new DataSet();

                    conn.Open();
                    da.Fill(ds);
                    conn.Close();

                    return ds;
                }
            }
            catch (Exception ex)
            {

                Ambiente.Mensaje(ex.Message);
                return null;
            }

        }
        public bool TestQuery(string SQL)
        {
            try
            {
                using (var db = new DymContext())
                {
                    SqlConnection conn = db.Database.GetDbConnection() as SqlConnection;
                    SqlDataAdapter da = new SqlDataAdapter();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = SQL;
                    da.SelectCommand = cmd;
                    DataSet ds = new DataSet();

                    conn.Open();
                    da.Fill(ds);
                    conn.Close();

                    return true;
                }
            }
            catch (Exception ex)
            {

                Ambiente.Mensaje(ex.ToString());
                return false;
            }

        }
    }
}
