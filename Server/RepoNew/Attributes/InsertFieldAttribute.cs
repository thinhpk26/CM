namespace Repo.Attributes
{
    /// <summary>
    /// Insert thêm những giá trị trong đối tượng thành field trong bảng
    /// </summary>
    public class InsertFieldAttribute : Attribute
    {
        public readonly string FieldEntity;
        public readonly string FieldActual;
        public InsertFieldAttribute(string fieldEntity, string fieldActual)
        {
            FieldActual = fieldActual;
            FieldEntity = fieldEntity;
        }
    }
}
