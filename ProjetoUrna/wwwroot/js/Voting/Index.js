$(document).ready(function () {
    var candidatoEscolhido = null;
    var votoFinalizado = false;

    $('#BotaoCorrige').click(function () {
        $('#AreaRenderizarNomeCandidato').html('');
        $('#AreaRenderizarNomeVice').html('');
        $('#PrimeiroDigitoLegenda').val('');
        $('#SegundoDigitoLegenda').val('');
        votoFinalizado = false;
        candidatoEscolhido = null;
    });


    $('button[name="BotaoUrna"]').click(function () {
        if (votoFinalizado == false) {
            var textoBotao = $(this).html();
            if (textoBotao == 'BRANCO') {
                $('#AreaRenderizarNomeCandidato').html('Voto em branco');
                $('#AreaRenderizarNomeVice').html('');
                candidatoEscolhido = null;
                votoFinalizado = true;
            }
            else {
                var primeiroDigito = $('#PrimeiroDigitoLegenda').val();
                var segundoDigito = $('#SegundoDigitoLegenda').val();

                if (!primeiroDigito) {
                    $('#PrimeiroDigitoLegenda').val(textoBotao);
                }
                else if (!segundoDigito) {
                    votoFinalizado = true;
                    $('#SegundoDigitoLegenda').val(textoBotao);

                    var tecla = primeiroDigito.concat(textoBotao);

                    $.get('/Candidate/recuperarPorLegenda', { tecla }).done(function (data) {
                        if (data == 'Voto nulo') {
                            $('#AreaRenderizarNomeCandidato').html(data);
                            $('#AreaRenderizarNomeVice').html('');
                            candidatoEscolhido = null;
                        }
                        else {
                            var candidate = JSON.parse(data);
                            $('#AreaRenderizarNomeCandidato').html(candidate.NomeCompleto);
                            $('#AreaRenderizarNomeVice').html(candidate.NomeVice);
                            candidatoEscolhido = candidate;
                        }
                    });
                }
            }
        }
    })

    $('#BotaoConfirma').click(function () {
        if (votoFinalizado) {
            if (candidatoEscolhido != null) {
                var candidatoJson = JSON.stringify(candidatoEscolhido);
            }
            else {
                var candidatoJson = '';
            }

            $.post('/Voting/vote', { candidatoJson }).done(function (data) {
                //Fazer a telinha de fim. E pressionar qualquer botão para voltar a tela de votação
                $('#BotaoCorrige').trigger('click');
            });
        }
    });
});