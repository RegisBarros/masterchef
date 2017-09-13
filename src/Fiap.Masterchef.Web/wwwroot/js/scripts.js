(function ($) {
    var cadastrar = function (form) {
        var receita = $(form).serializeFormJSON();

        var arquivos = $("#foto").get(0).files;

        var foto = new FormData();
        if (arquivos.length > 0) {
            foto.append(arquivos[0].name, arquivos[0]);
        }

        for (prop in receita) {
            foto.append(prop, receita[prop]);
        }

        $.ajax({
            url: 'receitas/CadastrarReceita',
            type: 'POST',
            contentType: false,
            processData: false,
            data: foto,
            success: function () {
                location.reload();
            }
        });
    };

    var validarFormulario = function () {
        $('#formReceita').validate({
            submitHandler: cadastrar.bind(this),
            rules: {
                titulo: {
                    required: true
                },
                descricao: {
                    required: true
                },
                categoriaId: {
                    required: true
                },
                foto: {
                    required: true
                },
                ingredientes: {
                    required: true
                },
                preparo: {
                    required: true
                }
            },
            messages: {
                titulo: {
                    required: 'requerido'
                },
                descricao: {
                    required: 'requerido'
                },
                categoriaId: {
                    required: 'requerido'
                },
                foto: {
                    required: 'requerido'
                },
                ingredientes: {
                    required: 'requerido'
                },
                preparo: {
                    required: 'requerido'
                }
            }
        });
    };

    var loadHelpers = function () {
        $.validator.setDefaults({
            errorClass: 'invalid',
            validClass: "valid",
            errorPlacement: function (error, element) {
                $(element)
                    .closest("form")
                    .find("label[for='" + element.attr("id") + "']")
                    .attr('data-error', error.text());
            }
        });

        $.fn.serializeFormJSON = function () {

            var o = {};
            var a = this.serializeArray();
            $.each(a, function () {
                if (o[this.name]) {
                    if (!o[this.name].push) {
                        o[this.name] = [o[this.name]];
                    }
                    o[this.name].push(this.value || '');
                } else {
                    o[this.name] = this.value || '';
                }
            });
            return o;
        };
    };

    $(function () {
        loadHelpers();

        $('.modal').modal();

        $('select').material_select();

        //$('.chips').material_chip({
        //    placeholder: 'add tags',
        //    secondaryPlaceholder: 'add tags',
        //});

        validarFormulario();

        $("#modalAddRecipes").on("click", "#salvar-receita", function () {
            $('#formReceita').submit();
        });
    });
})(jQuery);