using System;

namespace ARIOLI_HENSELMANN_MEKHILEF.Model
{
    public class Tag : IEquatable<Tag>
    {
        public string clr
        {
            get => _clr;
            set => _clr = value;
        }

        public int idt_pere
        {
            get => _idtPere;
            set => _idtPere = value;
        }

        public int idt_tag
        {
            get => _idtTag;
            set => _idtTag = value;
        }

        public string nom
        {
            get => _nom;
            set => _nom = value;
        }

        private int _idtPere;
        private int _idtTag;
        private string _nom;
        private string _clr;

        public Tag()
        {
        }

        public Tag(Tag tag) : this(tag.idt_tag, tag._nom, tag._clr, tag.idt_pere)
        {
        }

        public Tag(int idtTag, string nom, string clr)
        {
            idt_tag = idtTag;
            this.nom = nom;
            this.clr = clr;
        }

        public Tag(int idtTag, string nom, string clr, int idtPere)
        {
            idt_tag = idtTag;
            this.nom = nom;
            this.clr = clr;
            idt_pere = idtPere;
        }

        public bool Equals(Tag other)
        {
            if (other is null) return false;
            return (_idtTag == other.idt_tag && _nom == other._nom);
        }

        public override bool Equals(object obj) => Equals(obj as Tag);

        public override int GetHashCode() => (_idtTag, _nom).GetHashCode();

        public override string ToString() => nom;
    }
}