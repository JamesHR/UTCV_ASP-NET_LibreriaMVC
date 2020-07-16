namespace LibreriaMVC.Models
{
    public class UsuariosSalt 
    {
        public int Id {get; set;}
        public string Salt { get; set; }
        public Usuarios usuario { get; set;}

    }
}