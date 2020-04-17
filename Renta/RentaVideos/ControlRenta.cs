using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;
namespace RentaVideos
{
    public partial class ControlRenta : Form
    {
        conexion con = new conexion();
        public ControlRenta()
        {
            InitializeComponent();
            combo1.llenarse("material","MATERIAL","NOMBRE");
            combo2.llenarse("empleado", "EMPLEADO", "NOMBRES");
            
        datelimite.Format = DateTimePickerFormat.Custom;
         datelimite.CustomFormat = "yyyy-MM-dd";
            grb_detalle.Enabled = false;



        }

        
        

        private void Button1_Click(object sender, EventArgs e)
        {
            grb_encabezado.Enabled = false;
            grb_detalle.Enabled = true;
            string fecha;
            string empleado = idmelo2();

            fecha = DateTime.Now.ToString("yyyy-MM-dd");

            string sql = "iNSERT INTO renta_encabezado (MEMBRESIA,EMPLEADO,FECHA_INICIO, FECHA_FIN, DEVOLUCION, ESTADO) VALUES ("+txt_membre.Text+","+empleado +","+fecha+","+datelimite.Text+",0,1);";
            OdbcCommand command = new OdbcCommand(sql, con.conexion1());
            OdbcDataReader reader = command.ExecuteReader();
            llenartbl();


        }

          public string idmelo() {


               string idd;


               idd = combo1.obtenerP();

               switch (idd) {

                   case "0":
                    idd = "0";
                    break;

                 case "1":
                    idd = "1";
                    break;


                case "2":
                    idd = "2";
                    break;

                case "3":
                    idd = "3";
                    break;

                case "4":
                    idd = "4";
                    break;

                case "5":
                    idd = "5";
                    break;

                case "6":
                    idd = "6";
                    break;

                case "7":
                    idd = "7";
                    break;

                case "8":
                    idd = "8";
                    break;

                case "9":
                    idd = "9";
                    break;
                case "10":
                    idd = "10";
                    break;

                case "11":
                    idd = "11";
                    break;


                case "12":
                    idd = "12";
                    break;

                case "13":
                    idd = "13";
                    break;

                case "14":
                    idd = "14";
                    break;

                case "15":
                    idd = "15";
                    break;

                case "16":
                    idd = "16";
                    break;

                case "17":
                    idd = "17";
                    break;

                case "18":
                    idd = "18";
                    break;

                case "19":
                    idd = "19";
                    break;
                default:
                    idd = combo1.obtenerU();
                    break;
    
            }
            return idd;
        }
        public string idmelo2()
        {


            string idd;


            idd = combo2.obtenerP();

            switch (idd)
            {

                case "0":
                    idd = "0";
                    break;

                case "1":
                    idd = "1";
                    break;


                case "2":
                    idd = "2";
                    break;

                case "3":
                    idd = "3";
                    break;

                case "4":
                    idd = "4";
                    break;

                case "5":
                    idd = "5";
                    break;

                case "6":
                    idd = "6";
                    break;

                case "7":
                    idd = "7";
                    break;

                case "8":
                    idd = "8";
                    break;

                case "9":
                    idd = "9";
                    break;
                case "10":
                    idd = "10";
                    break;

                case "11":
                    idd = "11";
                    break;


                case "12":
                    idd = "12";
                    break;

                case "13":
                    idd = "13";
                    break;

                case "14":
                    idd = "14";
                    break;

                case "15":
                    idd = "15";
                    break;

                case "16":
                    idd = "16";
                    break;

                case "17":
                    idd = "17";
                    break;

                case "18":
                    idd = "18";
                    break;

                case "19":
                    idd = "19";
                    break;
                default:
                    idd = combo2.obtenerU();
                    break;

            }
            return idd;
        }

        void llenartbl()// al inicializar la tabla de usuarios
        {
            string sql = "select rd.ID_DETALLE, re.MEMBRESIA,re.EMPLEADO, m.NOMBRE, rd.PRECIO_UNIDAD,rd.CANTIDAD FROM renta_encabezado re INNER JOIN renta_detalle rd on re.ID_ENCABEZADO= rd.ID_ENCABEZADO INNER JOIN material m on m.MATERIAL=rd.MATERIAL where MEMBRESIA= "+txt_membre.Text+" and rd.estado=1;";
            OdbcCommand command = new OdbcCommand(sql,con.conexion1());
            OdbcDataAdapter adaptador = new OdbcDataAdapter(command);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);

            dgb_renta.DataSource = dt;
            adaptador.Update(dt);


        }


        public string precio(string art) {

            string precio="";
            string sql = "select PRECIO FROM material where MATERIAL= "+art +";";
            OdbcCommand command = new OdbcCommand(sql, con.conexion1());
            OdbcDataReader reader = command.ExecuteReader();


            if (reader.Read())
            {
                precio = reader.GetValue(0).ToString();

            }
            return precio;




        }
        private void Button3_Click(object sender, EventArgs e)
        {
          
        

            string idde = obtenerencabezado();
            string material = idmelo();
            string prec = precio(material);
            lbl_precio.Text = prec;

            //INSERT INTO `renta_detalle` (`ID_DETALLE`, `ID_ENCABEZADO`, `MATERIAL`, `PRECIO_UNIDAD`, `CANTIDAD`, `ESTADO`) VALUES (NULL, '1', '3', '10', '1', '1');
            string sql = "iNSERT INTO renta_detalle ( ID_ENCABEZADO, MATERIAL,PRECIO_UNIDAD,CANTIDAD) VALUES ("+idde+","+material+","+prec+","+txtcant.Text+");";
            OdbcCommand command = new OdbcCommand(sql, con.conexion1());
            OdbcDataReader reader = command.ExecuteReader();
            llenartbl();
            total();
        }


        public string obtenerencabezado() {
            string id = "";
            string sql = "select max(ID_ENCABEZADO)FROM renta_encabezado;";
            OdbcCommand command = new OdbcCommand(sql, con.conexion1());
            OdbcDataReader reader = command.ExecuteReader();


            if (reader.Read()) {
                id = reader.GetValue(0).ToString();

            }

            return id;

        }

        private void Combo1_Click(object sender, EventArgs e)
        {
        }

        private void Combo1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string material = idmelo();
            string prec = precio(material);
            lbl_precio.Text = prec;
        }

        private void Button4_Click(object sender, EventArgs e)
        {

            if (dgb_renta.SelectedRows.Count == 1)
            {
                string dato = dgb_renta.CurrentRow.Cells[0].Value.ToString();
                //UPDATE `renta_detalle` SET `ESTADO` = '0' WHERE `renta_detalle`.`ID_DETALLE` = 20 AND `renta_detalle`.`ID_ENCABEZADO` = 7;
                string sql = "UPDATE renta_detalle set ESTADO= 0  where ID_DETALLE = "+dato+"  ;";
                OdbcCommand command = new OdbcCommand(sql, con.conexion1());
                OdbcDataReader reader = command.ExecuteReader();
                llenartbl();
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void total()
        {
            string sql = "select sum(PRECIO_UNIDAD*CANTIDAD) from renta_detalle rd INNER JOIN renta_encabezado re on re.ID_ENCABEZADO=rd.ID_ENCABEZADO WHERE re.ESTADO=1 and  re.MEMBRESIA="+txt_membre.Text+";";
            OdbcCommand command = new OdbcCommand(sql, con.conexion1());
            OdbcDataReader reader = command.ExecuteReader();

            if (reader.Read()) {

                lbltotal.Text = reader.GetValue(0).ToString();
                    }
        }
        private void Combo1_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}
