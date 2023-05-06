namespace UnitySpace
{
    public class User
    {
        private int id ;
        private string name ;
        private string prenom ;
        private string password ;
        private string email ;
        private string post ;
        private string profil ;

        public User(int id, string name, string prenom, string password, string email, string post, string profil)
        {
            this.id = id;
            this.name = name;
            this.prenom = prenom;
            this.password = password;
            this.email = email;
            this.post = post;
            this.Profil = profil;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public string Post { get => post; set => post = value; }
        public string Profil { get => profil; set => profil = value; }
    }
}
