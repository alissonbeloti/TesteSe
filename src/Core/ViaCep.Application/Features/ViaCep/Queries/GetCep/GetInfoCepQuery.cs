using MediatR;

namespace ViaCep.Application.Features.ViaCep.Queries.GetCep;

public class GetInfoCepQuery : IRequest<InfoCepVm>
{
    public string _cep { get; set; } = String.Empty;

    public GetInfoCepQuery(string? cep)
    {
        _cep = cep ?? throw new ArgumentException(nameof(cep));
    }
}
