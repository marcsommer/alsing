﻿namespace CompositeDiagrammer
{
    using System.Drawing;
    using System.Drawing.Drawing2D;

    using QI4N.Framework;

    [Mixins(typeof(RectangleShapePathMixin))]
    public interface RectangleShape : Element2DComposite, Bordered, Filled, Containable , Selectable
    {
    }

    public class RectangleShapePathMixin : AbstractShapePathMixin
    {
        public override GraphicsPath GetPath()
        {
            var shape = new GraphicsPath();
            var bounds = new Rectangle(this.state.Left, this.state.Top, this.state.Width, this.state.Height);
            shape.AddRectangle(bounds);
            return shape;
        }
    }
}