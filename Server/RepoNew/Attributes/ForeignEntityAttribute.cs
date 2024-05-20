namespace Repo.Attributes
{
    public class ForeignEntityAttribute : Attribute
    {
        public readonly string FieldEntity;
        public readonly string FieldActual;
        public ForeignEntityAttribute(string fieldEntity, string fieldActual) 
        {
            FieldActual = fieldActual;
            FieldEntity = fieldEntity;
        }
    }
}
