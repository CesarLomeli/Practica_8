namespace Practica_6
{
    public partial class Form1 : Form
    {
        List<Memoria> lstMemoria = new List<Memoria>();
        List<archivos> lstArchivos = new List<archivos>();
        public Form1()
        {
            InitializeComponent();
            var archivos = llenarArchivos();
            correrMejorAjuste(archivos);
            correrPrimerAjuste(archivos);
            correrPeorAjuste(archivos);
            correrSiguienteAjuste(archivos);
            llenarMemoriaDinamica();
            llenarArchivosDinamicos();
        }

        public List<Memoria> llenarMemoria()
        {
            Memoria memoria = new Memoria();
            List<Memoria> lista = new List<Memoria>();
            listMemoriaOri.Items.Clear();
            foreach (var item in memoria.cargarMemoria())
            {
                lista.Add(item);
                listMemoriaOri.Items.Add(item.tamano + " Kb " + (item.estatus == false ? "Libre" : "Ocupada"));
            }
            return lista;
        }
        public List<archivos> llenarArchivos()
        {
            archivos archivos = new archivos();
            List<archivos> Listarchivos = new List<archivos>();
            foreach (var item in archivos.cargarArchivos("C:\\Users\\cesar\\OneDrive\\Documentos\\School\\Seminario de sistemas operativos\\Practica 6\\archivos.txt"))
            {
                Listarchivos.Add(item);
                listBoxArchivos.Items.Add(item.nombre + " tamaño: " + item.tamano + " kb");
            }
            return Listarchivos;
        }
        public void correrPrimerAjuste(List<archivos> archivos)
        {
            List<Memoria> memoria = new List<Memoria>();
            memoria = llenarMemoria();
            primerAjuste obj = new primerAjuste();
            foreach (var item in obj.algoritmo(archivos, memoria))
            {
                listBoxPrimerAjuste.Items.Add(item.tamano + " kb " + (item.estatus == true ? item.archivo.nombre : "Libre"));
            }
        }
        public void correrMejorAjuste(List<archivos> archivos)
        {
            List<Memoria> memoria = new List<Memoria>();
            memoria = llenarMemoria();
            mejorAjuste obj = new mejorAjuste();
            foreach (var item in obj.algoritmo(archivos, memoria))
            {
                listBoxMejorAjuste.Items.Add(item.tamano + " kb " + (item.estatus == true ? item.archivo.nombre : "Libre"));
            }
        }
        public void correrPeorAjuste(List<archivos> archivos)
        {
            List<Memoria> memoria = new List<Memoria>();
            memoria = llenarMemoria();
            peorAjuste obj = new peorAjuste();
            foreach (var item in obj.algoritmo(archivos, memoria))
            {
                listBoxPeorAjuste.Items.Add(item.tamano + " kb " + (item.estatus == true ? item.archivo.nombre : "Libre"));
            }
        }
        public void correrSiguienteAjuste(List<archivos> archivos)
        {
            List<Memoria> memoria = new List<Memoria>();
            memoria = llenarMemoria();
            siguienteAjuste obj = new siguienteAjuste();
            foreach (var item in obj.algoritmo(archivos, memoria))
            {
                listBoxSiguienteAjuste.Items.Add(item.tamano + " kb " + (item.estatus == true ? item.archivo.nombre : "Libre"));
            }
        }
        public List<Memoria> llenarMemoriaDinamica()
        {
            Memoria memoria = new Memoria();
            foreach (var item in memoria.cargarMemoria())
            {
                lstMemoria.Add(item);
                listMemoriaNueva.Items.Add(item.tamano + " Kb " + (item.estatus == false ? "Libre" : "Ocupada"));
            }
            return lstMemoria;
        }
        public List<archivos> llenarArchivosDinamicos()
        {
            archivos archivos = new archivos();
            foreach (var item in archivos.cargarArchivos("C:\\Users\\cesar\\OneDrive\\Documentos\\School\\Seminario de sistemas operativos\\Practica 6\\archivos.txt"))
            {
                lstArchivos.Add(item);
                listArchivosNuevos.Items.Add(item.nombre + " tamaño: " + item.tamano + " kb");
            }
            return lstArchivos;
        }
        public void imprimirResultado(List<Memoria> resultado)
        {
            listAlgoritmos.Items.Clear();
            foreach (var item in resultado)
            {
                listAlgoritmos.Items.Add(item.tamano + " kb " + (item.estatus == false ? "Libre" : item.archivo.nombre));
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Memoria newItem = new Memoria();
            newItem.estatus = (comboBox1.Text == "Libre" ? false : true);
            newItem.tamano = int.Parse(textBox1.Text);
            if (comboBox2.Text == "Inicio")
            {
                lstMemoria.Insert(0, newItem);
            }
            else
            {
                lstMemoria.Add(newItem);
            }
            listMemoriaNueva.Items.Clear();
            foreach (var item in lstMemoria)
            {
                listMemoriaNueva.Items.Add(item.tamano + " kb " + (item.estatus == false ? "Libre" : "Ocupado"));
            }
            textBox1.Text = string.Empty;
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            archivos newItem = new archivos();
            newItem.nombre = textBox2.Text;
            newItem.tamano = int.Parse(textBox3.Text);
            if (comboBox3.Text == "Inicio")
            {
                lstArchivos.Insert(0, newItem);
            }
            else
            {
                lstArchivos.Add(newItem);
            }
            listArchivosNuevos.Items.Clear();
            foreach (var item in lstArchivos)
            {
                listArchivosNuevos.Items.Add(item.nombre + " " + item.tamano + " kb");
            }
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            comboBox3.SelectedIndex = -1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            switch (comboBox4.SelectedIndex)
            {
                case 0:
                    primerAjuste primerAjuste = new primerAjuste();
                    List<Memoria> copiaMemoria = lstMemoria.Select(memoria => new Memoria
                    {
                        tamano = memoria.tamano,
                        estatus = memoria.estatus,
                        archivo = memoria.archivo != null ? new archivos { nombre = memoria.archivo.nombre, 
                            tamano = memoria.archivo.tamano } : null
                    }).ToList();
                    var resultado = primerAjuste.algoritmo(lstArchivos, copiaMemoria);
                    imprimirResultado(resultado);
                    break;
                case 1:
                    mejorAjuste mejorAjuste = new mejorAjuste();
                    List<Memoria> copiaAjuste = lstMemoria.Select(memoria => new Memoria
                    {
                        tamano = memoria.tamano,
                        estatus = memoria.estatus,
                        archivo = memoria.archivo != null ? new archivos { nombre = memoria.archivo.nombre, 
                            tamano = memoria.archivo.tamano } : null
                    }).ToList();
                    var resultadoAjuste = mejorAjuste.algoritmo(lstArchivos, copiaAjuste);
                    imprimirResultado(resultadoAjuste);
                    break;
                case 2:
                    peorAjuste peorAjuste = new peorAjuste();
                    List<Memoria> copiaPeor = lstMemoria.Select(memoria => new Memoria
                    {
                        tamano = memoria.tamano,
                        estatus = memoria.estatus,
                        archivo = memoria.archivo != null ? new archivos { nombre = memoria.archivo.nombre, tamano = memoria.archivo.tamano } : null
                    }).ToList();
                    var resultadoPeor = peorAjuste.algoritmo(lstArchivos, copiaPeor);
                    imprimirResultado(resultadoPeor);
                    break;
                case 3:
                    siguienteAjuste siguienteAjuste = new siguienteAjuste();
                    List<Memoria> copiaSiguiente = lstMemoria.Select(memoria => new Memoria
                    {
                        tamano = memoria.tamano,
                        estatus = memoria.estatus,
                        archivo = memoria.archivo != null ? new archivos { nombre = memoria.archivo.nombre, tamano = memoria.archivo.tamano } : null
                    }).ToList();
                    var resultadoSiguiente = siguienteAjuste.algoritmo(lstArchivos, copiaSiguiente);
                    imprimirResultado(resultadoSiguiente);
                    break;
            }
        }
    }
}
