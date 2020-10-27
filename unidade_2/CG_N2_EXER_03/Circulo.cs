using System;
using System.Collections.Generic;
using System.Text;
using CG_Biblioteca;
using gcgcg;
using OpenTK.Graphics.OpenGL;

namespace CG_N2
{
    internal class Circulo : ObjetoGeometria
    {
        public Circulo(int graus, string rotulo, Objeto paiRef, int x, int y) : base(rotulo, paiRef)
        {

            int qtdPts = 72;
            this.PrimitivaTipo = PrimitiveType.Points;
            int angulo = 0;

            Ponto4D pt;
            for (int i = 1; i <= qtdPts; i++)
            {
                angulo += 5;
                pt = Matematica.GerarPtosCirculo(angulo, 100);
                pt.X += x;
                pt.Y += y;
                base.PontosAdicionar(pt);
            }
        }

        protected override void DesenharObjeto()
        {
            GL.PointSize(3);
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
