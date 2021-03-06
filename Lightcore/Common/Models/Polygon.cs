﻿namespace Lightcore.Common.Models
{
    using Lightcore.Textures.Models;
    using System;
    using System.Linq;

    public class Polygon : Indexable<Vector>, IClonable<Polygon>, ITransformable
    {
        public Polygon(Texture texture, Vector[] values, Guid? id = null) : base(values)
        {
            Texture = texture;
            Id = id.GetValueOrDefault(Guid.NewGuid());
        }

        public Guid Id { get; set; }

        public Texture Texture { get; set; }

        public PolygonType PolygonType
        {
            get
            {
                if (Elements.Length == 2)
                    return PolygonType.Line;
                if (Elements.Length == 3)
                    return PolygonType.Triangle;
                throw new Exception();
            }
        }

        public Polygon Clone()
        {
            return new Polygon(Texture.Clone(), Elements.Select(vector => vector.Clone()).ToArray(), Id);
        }

        public void Transform(Func<Vector, Vector> transformation)
        {
            for (int i = 0; i < Elements.Count(); i++)
            {
                Elements[i] = Elements[i].Transform(transformation);
            }
        }
    }
}
