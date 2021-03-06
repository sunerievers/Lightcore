﻿namespace Lightcore.Lighting.Models
{
    using Lightcore.Common.Models;
    using System;

    public class AngleLight : DirectLight
    {
        public AngleLight (Vector color, Vector position, Vector direction, double strength, double angle, Guid? origin = null, Guid? id = null, int generation = 0) : base (color, position, direction, strength, origin, id, generation)
        {
            Angle = angle;
        }

        public double Angle { get; set; }

        public override Light Clone()
        {
            return new AngleLight(Color, Position.Clone(), Direction.Clone(), Strength, Angle, PolygonId, Id, Generation);
        }

        public override void Transform(Func<Vector, Vector> transformation)
        {
            Position = transformation(Position);
            Direction = transformation(Direction);
        }
    }
}
