using MediatR;

using RestSharp;

namespace ViaCep.Application.Features.ViaCep.Queries.GetCep;

public class GetInfoCepQueryHandler : IRequestHandler<GetInfoCepQuery, InfoCepVm>
{
    public async Task<InfoCepVm> Handle(GetInfoCepQuery request, CancellationToken cancellationToken)
    {
        var client = new RestClient("http://viacep.com.br");

        var requestCep = new RestRequest($"ws/{request._cep}/json/", Method.Get);

        
        var response = await client.GetAsync<InfoCepVm>(requestCep);

        return response;

    }
}
