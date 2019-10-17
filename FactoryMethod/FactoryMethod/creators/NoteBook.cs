using FactoryMethod.products;

namespace FactoryMethod.creators
{
    class Notebook : Store
    {
        public Product getProduct(string Name)
        {
            if (Name == "Apple MacBook")
            {
                return new AppleMacBook();
            }
            if (Name == "Xiaomi NoteBook")
            {
                return new XiaomiNoteBook();
            }
            return new XiaomiNoteBook();

        }
    }
}
