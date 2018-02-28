using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XML 
{
    [Serializable]
	public class Complex
	{
        public int x;
        public int y; //my variables will be in the form x+yi

		public Complex(int x, int y) //constructor
		{
			this.x = x; //присваиваю значения
			this.y = y;
		}
        public Complex ()
        {

        }
        public static Complex operator +(Complex c1, Complex c2)
		{
        Complex n = new Complex(); //new complex number
            n.x = c1.x + c2.x; //new variable, responding for part of number without i
			n.y = c1.y + c2.y; //new variable, responding for part of number with i
			return n;
		}
        
        /*public static Complex operator *(Complex c1, Complex c2)
        { 
        int a = (c1.x* c2.x) - (c1.y*c2.y);  //new variable, responding for part of number without i
		int b = (c1.x * c2.y) + (c2.x*c1.y); //new variable, responding for part of number with i
		Complex m = new Complex(a, b);
        return m;
		}*/

		public override string ToString() //переписываю метод
		{
			return x + " + " + y + "i"; //my answer will return in this form
		}
	}
	class Program
	{
        static void SER() 
        {
            FileStream fs = new FileStream(@"maks.xml", FileMode.OpenOrCreate, FileAccess.Write);
            XmlSerializer xs = new XmlSerializer(typeof(Complex));
            Complex C = new Complex(3, 7);
            try
            {
                xs.Serialize(fs, C);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }
            Console.WriteLine("Done. Please, go to the file");
        }
        static Complex DESER()  
        {
            FileStream fs = new FileStream(@"maks.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(Complex));
          
            Complex n = xs.Deserialize(fs) as Complex;
            fs.Close();
            return n;
        }
        static void Main(string[] args)
        {
            SER();
            Console.WriteLine(DESER());
            
		}
	}
}
