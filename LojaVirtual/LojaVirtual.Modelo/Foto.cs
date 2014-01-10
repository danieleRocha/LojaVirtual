using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace LojaVirtual.Modelo
{
    public class Foto
    {
        public Guid Id { get; set; }
        public MemoryStream DadosEmMemoria { get; set; }

        public Bitmap ObterImagem()
        {
            Bitmap bitmapImage = null;

            if (DadosEmMemoria != null)
                bitmapImage = new Bitmap(DadosEmMemoria);

            return bitmapImage;
        }
    }
}
