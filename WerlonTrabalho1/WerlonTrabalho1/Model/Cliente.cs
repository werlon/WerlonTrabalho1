using SQLite.Net.Attributes;

namespace WerlonTrabalho1.Model
{
    [Table("Cliente")]
    class Cliente
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Nome { get; set; }

        [MaxLength(100)]
        public string Sobrenome { get; set; }

        [MaxLength(14)]
        public string Cpf { get; set; }

        [MaxLength(60)]
        public string Email { get; set; }

        public override string ToString()
        {
            return string.Format("Id:{0}, Cliente:{1}, CPF:{2}, Email:{3}",Id,Nome+" "+Sobrenome,Cpf,Email);
        }
    }
}
