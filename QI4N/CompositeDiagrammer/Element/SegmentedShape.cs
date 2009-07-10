﻿namespace CompositeDiagrammer
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;

    using QI4N.Framework;

    public interface SegmentedShapeComposite : SegmentedShape, ShapeComposite
    {
    }

    [Mixins(typeof(SegmentedShapeMixin))]
    public interface SegmentedShape : Shape
    {
        void MoveSelectedNodes(int offsetX, int offsetY);

        void MoveNode(int nodeIndex, int offsetX, int offsetY);

        void SetNodeLocation(int nodeIndex, int x, int y);

        void Move(int offsetX, int offsetY);

        void Rotate(double angle);
    }

    public interface Nodes
    {
        IList<SegmentedShapeNode> Get();

        Point[] GetPoints();
    }

    public class SegmentedShapeMixin : SegmentedShape
    {
        [This]
        private Nodes nodes;

        [This]
        private Path path;

        private readonly IList<SegmentedShapeNode> selectedNodes = new List<SegmentedShapeNode>();

        public void Move(int offsetX, int offsetY)
        {
            foreach (SegmentedShapeNode node in this.nodes.Get())
            {
                node.X += offsetX;
                node.Y += offsetY;
            }
        }

        public void MoveNode(int nodeIndex, int offsetX, int offsetY)
        {
            SegmentedShapeNode node = this.nodes.Get()[nodeIndex];
            node.X += offsetX;
            node.Y += offsetX;
        }

        public void MoveSelectedNodes(int offsetX, int offsetY)
        {
            foreach (SegmentedShapeNode node in this.selectedNodes)
            {
                node.X += offsetX;
                node.Y += offsetY;
            }
        }

        public void Rotate(double angle)
        {
        }

        public void SetNodeLocation(int nodeIndex, int x, int y)
        {
            SegmentedShapeNode node = this.nodes.Get()[nodeIndex];
            node.X = x;
            node.Y = y;
        }

        public void Render(RenderInfo renderInfo)
        {
            using (GraphicsPath graphicsPath = this.path.Get())
            {
            }
        }
    }

    public class SegmentedShapeNode
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Point ToPoint()
        {
            return new Point(X,Y);
        }
    }
}