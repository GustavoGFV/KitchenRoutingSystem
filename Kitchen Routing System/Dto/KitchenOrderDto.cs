using Kitchen_Routing_System.Dto.Enum;

namespace Kitchen_Routing_System.Dto
{
    /// <summary>
    /// #1 Uma rapida anotação, o Id seria utilizado realmente em uma estrutura que houvesse banco de dados, apesar de não ser utilizada aqui é sempre importante te-la presente.
    /// #2 O Id de estabelecimento foi idealizado no sentido deste programa ser utilizado por mais de um estabelecimento ao mesmo tempo se hospedando em um unico servidor, no caso, o campo deveria vir preenchido de acordo com as configurações das maquinas locais que abriram a requisição.
    /// </summary>
    /// 
    /// <summary>
    /// #1 Quick Note, the Id parament would be utilized in a database structer, even though is not used here is always important to have it.
    /// #2 The Establishment Id was idealized in a way that, what if the program needed to run in only one server for several establishments, this field would be filled by the local system that made the request.
    /// </summary>

    public class KitchenOrderDto
    {
        public int? Id { get; set; }
        public int OrderId { get; set; }
        public int EstablishmentId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public AreaEnum Area { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
