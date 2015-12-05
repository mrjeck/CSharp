using System;
using WONDERS;

namespace DZ_CS_3._4

{
    class Program
    {
        static void Main()
        {
            First_Wonder w1 = new First_Wonder("Temple of goddess Diana or Artemis");
            Second_Wonder w2 = new Second_Wonder("Colossus at Rhodes");
            Third_Wonder w3 = new Third_Wonder("The Hanging Gardens of Babylon");
            Fourth_Wonder w4 = new Fourth_Wonder("The Statue of Zeus or Jupiter");
            Fifth_Wonder w5 = new Fifth_Wonder("Pharos of Alexandria");
            Sixth_Wonder w6 = new Sixth_Wonder("The Mausoleum of Halicarnassus");
            Seventh_Wonder w7 = new Seventh_Wonder("The Great Pyramid of Giza in Egypt");
            w1.show();
            w2.show();
            w3.show();
            w4.show();
            w5.show();
            w6.show();
            w7.show();
        }
    }
}
