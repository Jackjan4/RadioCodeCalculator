using System;
using System.IO;

namespace RadioCodeCalculator
{
    static class Program
    {
        public static int[] secret = { 8, 0, 5, 7, 9, 2, 6, 1, 4, 3, 1, 2, 4, 9, 8, 3, 0, 6, 5, 7, 7, 8, 9, 4, 3, 6, 1, 0, 2, 5, 2, 9, 8, 0, 7, 5, 4, 3, 6, 1, 0, 4, 1, 5, 6, 7, 2, 9, 3, 8, 9, 6, 0, 1, 5, 4, 3, 7, 8, 2, 6, 7, 3, 8, 2, 1, 9, 5, 0, 4, 5, 3, 6, 2, 1, 0, 8, 4, 7, 9, 3, 1, 7, 6, 4, 8, 5, 2, 9, 0, 4, 5, 2, 3, 0, 9, 7, 8, 1, 6 };

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int[] serial = { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 };
            string result = Calc(serial);
        }




        /// <summary>
        /// 
        /// </summary>
        static int Loop(int normal, int timesTen)
        {
            int id = normal + timesTen * 10;
            return secret[id];
        }

        static string Calc(int[] serial)
        {
            // Serial + 0 entspricht der zweiten Zahl im Serial. Die erste macht nix.

            var loop1 = Loop(serial[0], serial[5]);
            var loop2 = Loop(serial[9], serial[6]);
            var loop3 = Loop(loop2, serial[7]);
            var loop4 = Loop(loop3, serial[8]);
            var loop5 = Loop(loop4, serial[9]);
            var loop6 = Loop(loop2, loop4);
            var loop7 = Loop(loop3, loop5);
            var loop8 = Loop(serial[4], serial[1]);
            var loop9 = Loop(loop8, serial[2]);
            var loop10 = Loop(loop9, serial[3]);
            var loop11 = Loop(loop10, serial[4]);
            var loop12 = Loop(loop8, loop10);
            var loop13 = Loop(loop9, loop11);
            var loop14 = Loop(loop5, loop11);
            var loop15 = Loop(loop1, loop14);
            var loop16 = Loop(loop4, loop10);
            var loop17 = Loop(loop1, loop16);

            //// Phase 2 byte 454C31
            int byte_454C31 = loop17;

            var loop18 = Loop(loop7, loop13);
            var loop19 = Loop(loop1, loop18);

            //// Phase 2 byte_454C32
            int byte_454C32 = loop19;

            var loop20 = Loop(loop6, loop12);
            var loop21 = Loop(loop1, loop20);

            //// Phase 2 byte_454C33
            int byte_454C33 = loop21;

            if (loop20 + loop15 == 0) {
                loop15 = 1;
                loop17 = 3;
                loop21 = 2;
            }

            int result = loop21 + loop19 * 10 + loop17 * 100 + loop15 * 1000;
            //lea     edx, [ebp+var_18]

            return result.ToString();

            // TODO: Zweiten code anzeigen
        }

        
    }
}
