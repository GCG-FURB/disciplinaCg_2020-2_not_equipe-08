using System;
using System.Collections.Generic;
using System.Text;
using CG_Biblioteca;
using gcgcg;
using OpenTK.Graphics.OpenGL;

namespace CG_N2
{
    internal class SegReta : ObjetoGeometria
    {
        public SegReta(Ponto4D pt1, Ponto4D pt2, string rotulo, Objeto paiRef) : base(rotulo, paiRef)
        {
            this.PrimitivaTipo = PrimitiveType.Lines;
            base.PontosAdicionar(new Ponto4D(pt1.X, pt1.Y));
            base.PontosAdicionar(new Ponto4D(pt2.X, pt2.Y));
        }

        protected override void DesenharObjeto()
        {
            GL.PointSize(5);
            GL.Begin(base.PrimitivaTipo);
            foreach (Ponto4D pto in pontosLista)
            {
                GL.Vertex2(pto.X, pto.Y);
            }
            GL.End();
        }

        //TODO: melhorar para exibir não só a lsita de pontos (geometria), mas também a topologia ... poderia ser listado estilo OBJ da Wavefrom
        public override string ToString()
        {
            string retorno;
            retorno = "__ Objeto Circulo: " + base.rotulo + "\n";
            for (var i = 0; i < pontosLista.Count; i++)
            {
                retorno += "P" + i + "[" + pontosLista[i].X + "," + pontosLista[i].Y + "," + pontosLista[i].Z + "," + pontosLista[i].W + "]" + "\n";
            }
            return (retorno);
        }

    }
}
