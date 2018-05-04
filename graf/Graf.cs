using System;
using System.Collections.Generic;

namespace graf {
  class Susedi {
    private List<GrafVertex> vertexi;

    public Susedi() {
      vertexi = new List<GrafVertex>();
    }
    public void addSused(GrafVertex vertex) {
      vertexi.Add(vertex);
    }
    public void removeSused(GrafVertex vertex) {
      foreach (GrafVertex v in vertexi) {
        if (v == vertex) {
          vertexi.Remove(v);
        }
      }
    }
    public override string ToString() {
      string str = "[";
      foreach (GrafVertex v in vertexi) {
        str += " " + v.ID;
      }
      str += " ]";
      return str;
    }
  }
  class GrafVertex {
    private int data;
    public int Data {
      get { return data; }
    }
    private string id;
    public string ID {
      get { return id; }
    }
    private Susedi susedi;
    public Susedi Susedi {
      get { return susedi; }
    }

    public GrafVertex(string id, int data = 0) {
      this.id = id;
      this.data = data;
      this.susedi = new Susedi();
    }
  }
  class Graf {
    private List<GrafVertex> vertexi;
    public List<GrafVertex> Vertexi {
      get { return vertexi; }
    }

    public Graf() {
      vertexi = new List<GrafVertex>();
    }
    public Graf(List<GrafVertex> vertexi) {
      vertexi.CopyTo(this.vertexi.ToArray());
    }
    public void addVertex(GrafVertex vertex) {
      vertexi.Add(vertex);
    }
    public void addSused(GrafVertex vertex, GrafVertex sused) {
      foreach (GrafVertex v in vertexi) {
        if (v == vertex) {
          v.Susedi.addSused(sused);
        }
      }
    }
    public void removeSused(GrafVertex vertex, GrafVertex sused) {
      foreach (GrafVertex v in vertexi) {
        if (v == vertex) {
          v.Susedi.removeSused(sused);
        }
      }
    }
    public void removeVertex(GrafVertex vertex) {
      foreach (GrafVertex v in vertexi) {
        if (v == vertex) {
          vertexi.Remove(v);
        }
      }
    }
    public override string ToString() {
      string str = "";

      foreach (GrafVertex v in vertexi) {
        str += string.Format("({0}, {1}) ", v.ID, v.Data);
        str += v.Susedi;
        str += " ";
      }

      return str;
    }
  }
}