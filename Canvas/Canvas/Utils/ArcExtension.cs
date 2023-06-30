using netDxf;
using netDxf.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace Canvas.Utils
{
  /// <summary>
  /// netDxf弧线扩展类
  /// </summary>
  public static class ArcExtension
  {
    public static Vector3 StartPoint(this Arc arc)
    {
      return GetEndPoint(arc, arc.StartAngle);
    }

    public static Vector3 EndPoint(this Arc arc)
    {
      return GetEndPoint(arc, arc.EndAngle);
    }

    private static Vector3 GetEndPoint(Arc arc, double angle)
    {
      double sine = arc.Radius * Math.Sin(angle);
      double cosine = arc.Radius * Math.Cos(angle);

      var v = new Vector3(cosine, sine, 0);

      Vector3 ocsCenter = MathHelper.Transform(arc.Center, arc.Normal, CoordinateSystem.World, CoordinateSystem.Object);

      return new Vector3(v.X + ocsCenter.X, v.Y + ocsCenter.Y, ocsCenter.Z);
    }
  }
}