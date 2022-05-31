using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patron_Command
{
    public interface Command
    {
        void execute();
    }
    public interface CommandAudio
    {
        void execute(int a);
    }
    public interface CommandSong
    {
        void execute(string artista, string song);
    }

    public class Luces
    {
        public bool conectar()
        {
            try
            {
                Console.WriteLine("Conectando al sistema de iluminación...");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: No se ha podido establecer la conexión al sistema de iluminación.");
                return false;
            }

        }
        public bool desconectar()
        {
            Console.WriteLine("Desconectando al sistema de iluminación...");
            try
            {
                Console.WriteLine("Se ha desconectado del sistema de iluminación.");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: No se ha podido desconectar del sistema de iluminación.");
                return false;
            }
        }
        public bool encender()
        {
            Console.WriteLine("Encendiendo el sistema de iluminación...");
            try
            {
                Console.WriteLine("Sistema de iluminación encendido.");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: No se ha podido encender el sistema de iluminación.");
                return false;
            }
        }
        public bool apagar()
        {
            Console.WriteLine("Apagando el sistema de iluminación...");
            try
            {
                Console.WriteLine("Sistema de iluminación apagado.");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: No se ha podido apagar el sistema de iluminación.");
                return false;
            }
        }
    }
    public class computadora
    {
        public bool Conectar()
        {
            Console.WriteLine("Conectando al interruptor...");
            try
            {
                Console.WriteLine("Conexion al interruptor establecida.");
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine("ERROR: No se ha podido establecer conexion al interruptor.");
                return false;
            }
        }
        public bool Desconectar()
        {
            Console.WriteLine("Desconectando del interruptor...");
            try
            {
                Console.WriteLine("Se ha desconectado del interruptor.");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: No se ha podido desconectar dell interruptor.");
                return false;
            }
        }
        public bool Encender()
        {
            Console.WriteLine("Encendiendo el interruptor: Computadora...");
            try
            {
                Console.WriteLine("Computadora encendida.");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: No se ha podido encender el interruptor.");
                return false;
            }
        }
        public bool Apagar()
        {
            Console.WriteLine("Apagando el interruptor: Computadora...");
            try
            {
                Console.WriteLine("Computadora apagada.");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: No se ha podido apagar el interruptor.");
                return false;
            }
        }

    }
    public class Audio
    {
        public bool Conectar()
        {
            Console.WriteLine("Conectando al sistema de audio...");
            try
            {
                Console.WriteLine("Conexión al sistema de audio establecida.");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: No se ha podido establecer la conexión al sistema de audio.");
                return false;
            }
        }
        public bool desconectar()
        {
            Console.WriteLine("Desconectando del sistema de audio...");
            try
            {
                Console.WriteLine("Se ha desconectado del sistema de audio satisfactoriamente.");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: No se ha podido desconectar del sistema de audio.");
                return false;
            }
        }
        public bool volumen(int vol)
        {
            Console.WriteLine("Configurando el volumen a " + vol + "%...");
            try
            {
                Console.WriteLine("Volumen actualizado.");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: No se ha podido configurar el volumen.");
                return false;
            }
        }
        public bool reproducir(string artista, string song)
        {
            Console.WriteLine("Buscando la cancion: " + song + " de " + artista + "...");
            try
            {
                Console.WriteLine("Reproduciendo " + song + " de " + artista + ".");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: No se ha podido encontrar la canción " + song + ".");
                return false;
            }
        }
    }
    public class EncenderLuces : Command
    {
        private Luces luces;

        public EncenderLuces()
        {
            this.luces = new Luces();
        }
        public void execute()
        {
            luces.conectar();
            luces.encender();
            luces.desconectar();
        }
    }

    public class ApagarLuces : Command
    {
        private Luces luces;
        public ApagarLuces()
        {
            this.luces = new Luces();
        }
        public void execute()
        {
            luces.conectar();
            luces.apagar();
            luces.desconectar();

        }
    }
    public class ConfigAudio : CommandAudio
    {
        private Audio audio;

        public ConfigAudio()
        {
            this.audio = new Audio();
        }
        public void execute(int a)
        {
            audio.Conectar();
            audio.volumen(a);
            audio.desconectar();
        }
    }
    public class PlaySong : CommandSong
    {
        private Audio playsong;

        public PlaySong()
        {
            this.playsong = new Audio();
        }
        public void execute(string ar, string so)
        {
            playsong.Conectar();
            playsong.reproducir(ar, so);
            playsong.desconectar();
        }
    }
    public class EncenderComputadora : Command
    {
        private computadora compu;
        public EncenderComputadora()
        {
            this.compu = new computadora();
        }
        public void execute()
        {
            compu.Conectar();
            compu.Encender();
            compu.Desconectar();
        }
    }
    public class ApagarComputadora : Command
    {
        private computadora compu;
        public ApagarComputadora()
        {
            this.compu = new computadora();
        }
        public void execute()
        {
            compu.Conectar();
            compu.Apagar();
            compu.Desconectar();
        }
    }
    public class InvokerV
    {
        private CommandAudio ordenaudio;
        public InvokerV(CommandAudio commandAudio)
        {
            this.ordenaudio = commandAudio;
        }
        public void runV(int a)
        {
            ordenaudio.execute(a);
        }

    }
    public class InvokerS
    {
        private CommandSong ordensong;
        public InvokerS(CommandSong commandSong)
        {
            this.ordensong = commandSong;
        }
        public void runS(string ar, string so)
        {
            ordensong.execute(ar, so);
        }

    }
    public class Invoker
    {
        private Command orden;

        public Invoker(Command orden)
        {
            this.orden = orden;
        }

        public void run()
        {
            orden.execute();
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int e = 0;
            do
            {
                Command command = null;
                CommandAudio commandAudio = null;
                CommandSong commandSong = null;

                int a = 0, vol = 0;
                string artista = "", song = "";

                Console.WriteLine("Seleccione alguna opcion:");
                Console.WriteLine("1: Encender las luces");
                Console.WriteLine("2: Apagar las luces");
                Console.WriteLine("3: Reproducir una cancion");
                Console.WriteLine("4: Configurar volumen");
                Console.WriteLine("5: Encender computadora");
                Console.WriteLine("6: Apagar computadora");
                Console.WriteLine("7: Salir");
                try
                {
                    a = Convert.ToInt16(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Ingrese solo números");
                    Console.ReadKey();
                    Console.Clear();
                }
                switch (a)
                {
                    case 1:
                        command = new EncenderLuces();
                        break;
                    case 2:
                        command = new ApagarLuces();
                        break;
                    case 3:
                        Console.WriteLine("¿Cúal es el nombre de la cancion?");
                        song = Console.ReadLine();
                        Console.WriteLine("¿Quién es el artista?");
                        artista = Console.ReadLine();

                        commandSong = new PlaySong();
                        break;
                    case 4:
                        Console.WriteLine("¿Qué valor de volumen quiere?");
                        vol = Convert.ToInt32(Console.ReadLine());

                        commandAudio = new ConfigAudio();
                        break;
                    case 5:
                        command = new EncenderComputadora();
                        break;
                    case 6:
                        command = new ApagarComputadora();
                        break;
                    case 7:
                        e = 1;
                        break;
                    default:
                        break;
                }
                if (command != null)
                {
                    Invoker invoker = new Invoker(command);
                    invoker.run();
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (commandSong != null)
                {
                    InvokerS invokerS = new InvokerS(commandSong);
                    invokerS.runS(artista, song);
                    Console.ReadKey();
                    Console.Clear();

                }
                else if (commandAudio != null)
                {
                    InvokerV invokerV = new InvokerV(commandAudio);
                    invokerV.runV(vol);
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (e == 0);

        }
    }
}
