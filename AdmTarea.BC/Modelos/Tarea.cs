namespace AdmTarea.BC.Modelos
{
    public  class Tarea
    {
        public long id { get; set; }
        public string nombre { get; set; }
        public bool estaListo { get; set; }
        public string? secreto { get; set; }
    }
}
