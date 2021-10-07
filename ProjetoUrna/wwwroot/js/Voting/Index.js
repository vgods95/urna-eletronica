$(document).ready(function () {

    $('button[name="BotaoUrna"]').click(function () {
        var textoBotao = $(this).html();
        if (textoBotao == 'BRANCO') {
            $('#AreaRenderizarNomeCandidato').html('Voto em branco');
            $('#AreaRenderizarNomeVice').html('');
        }
        else {
            var primeiroDigito = $('#PrimeiroDigitoLegenda').val();
            var segundoDigito = $('#SegundoDigitoLegenda').val();

            if (!primeiroDigito) {
                $('#PrimeiroDigitoLegenda').val(textoBotao);
            }
            else if (!segundoDigito) {
                $('#SegundoDigitoLegenda').val(textoBotao);

                var tecla = primeiroDigito.concat(textoBotao);

                $.get('/Candidate/recuperarPorLegenda', { tecla }).done(function (data) {
                    if (data == 'Voto nulo') {
                        $('#AreaRenderizarNomeCandidato').html(data);
                        $('#AreaRenderizarNomeVice').html('');
                    }
                    else {
                        var candidate = JSON.parse(data);
                        $('#AreaRenderizarNomeCandidato').html(candidate.NomeCompleto);
                        $('#AreaRenderizarNomeVice').html(candidate.NomeVice);
                    }
                });
            }
        }
    })

    //Fazer a telinha de fim. E pressionar qualquer botão para voltar a tela de votação
            //O Id do candidato não é mais um campo obrigatório, portanto se não tiver preenchido contabilizar como um voto branco ou nulo
});