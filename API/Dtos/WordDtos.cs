namespace API.Dtos;

public class G_WordDto
{
    public int Id { get; set; }

    public string Word { get; set; }

    public sbyte Plural { get; set; }

    public virtual VerbalTenseDescriptionDto VerbalTense { get; set; }

    public virtual WordTypeDescriptionDto WordType { get; set; }

    public string Translation { get; set; }


}
