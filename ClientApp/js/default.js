(function (execute) {

    execute(window.jQuery, window, document);

}(function ($, window, document) {

    var self = this;
    self.controls = null;
    self.formValidationRules = null;
    self.endpointUrl = 'http://localhost:27994/api/v1/employees';

    $(function () {

        self.validateFormValidation();
        self.loadControlsCache();
        self.configureFormEvents();
        self.configureUiWidgets();        

    });

    self.validateFormValidation = function () {

        var rules = defaultFormValidationRules;
        if (!rules) {
            console.error('Unable to initialize the form!');
            return;
        }

        self.formValidationRules = rules;

    };

    self.loadControlsCache = function () {

        self.controls = {
            registrationForm: $('#registrationForm'),
            fullNameField: $('#fullName'),
            dobField: $('#dob'),
            ssnField: $('#ssn'),
            salaryField: $('#salary'),
            operationsMessageModal: $('#operationsMessageModal'),
            operationsMessageModalTitle: $('#operationsMessageModal').find('.modal-title'),
            operationsMessageModalBody: $('#operationsMessageModal').find('.modal-body'),
            submitButton: $('#submitButton'),
            clearButton: $('#clearButton'),
            btnCloseModal: $('#btnCloseModal')
        };

    };

    self.configureFormEvents = function () {

        if (!self.controls) {
            console.error('Form controls cache not loaded!');
            return;
        }

        self.controls.submitButton.on('click', self.submitButton_Click);
        self.controls.clearButton.on('click', self.clearButton_Click);
        self.controls.btnCloseModal.on('click', function () { self.toggleOperationsModal(); })
        self.controls.operationsMessageModal.on('hidden.bs.modal', self.operationsMessageModal_Hidden);

    };

    self.configureUiWidgets = function () {
        self.controls.dobField.datepicker({ language: 'pt-BR' });
        self.controls.dobField.mask('99/99/9999');
        self.controls.ssnField.mask('999.999.999-99', { autoclear: false });
        self.controls.salaryField.maskMoney({ prefix: 'R$', thousands : '.', decimal : ',' });
    }

    self.toggleOperationsModal = function () {
        self.controls.operationsMessageModal.modal('toggle', { clearFormData : true });
    }

    self.setModalMessage = function (data) {
        if (data) {
            $('<p />').html(data.message).appendTo(self.controls.operationsMessageModalBody);

            if (data.failureDetails) {

                self.controls.operationsMessageModalTitle.html('Por favor, revise o(s) erro(s) a seguir e tente novamente');

                for (var index in data.failureDetails) {
                    $('<p />').html(data.failureDetails[index].description).appendTo(self.controls.operationsMessageModalBody);
                }

            } else {
                self.controls.operationsMessageModalTitle.html('Sucesso!');
            }
        } else {
            self.controls.operationsMessageModalTitle.html('Desculpe-nos!');
            $('<p />').html('Houve um erro técnico ao tentar processar a solicitação.').appendTo(self.controls.operationsMessageModalBody);
            $('<p />').html('Por favor, entre em contato com o suporte técnico/administrador da aplicação e reporte o erro.').appendTo(self.controls.operationsMessageModalBody);
        }
    }

    self.getFormData = function () {

        return {
            fullName: self.controls.fullNameField.val().trim(),
            dob: self.controls.dobField.datepicker('getDate'),
            ssn: self.controls.ssnField.val().replace(/\D/gi, ''),
            salary: self.controls.salaryField.maskMoney('unmasked')[0]
        };

    }

    self.clearFormData = function () {
        self.controls.registrationForm.find('input').val('');
    }

    self.submitButton_Click = function () {

        var form = self.controls.registrationForm;

        form.validate(self.formValidationRules);

        if (form.valid()) {

            var formData = self.getFormData();

            self.submitData(formData)
                .done(function (data) {
                    self.setModalMessage(data);
                    self.toggleOperationsModal();
                    self.clearFormData();
                })
                .catch(function (data) {
                    self.setModalMessage(data.responseJSON);
                    self.toggleOperationsModal();
                });
        }

    };

    self.clearButton_Click = function () {

        self.clearFormData();

    };

    self.operationsMessageModal_Hidden = function () {
        self.controls.operationsMessageModalTitle.html('');
        self.controls.operationsMessageModalBody.html('');
    }

    self.submitData = function (data) {
        return $.ajax({
            url: self.endpointUrl,
            type: 'POST',
            data: JSON.stringify(data),
            contentType: 'application/json',
            dataType: 'json',
            beforeSend: function () { self.controls.submitButton.prop('disabled', 'disabled'); },
            complete: function () { self.controls.submitButton.prop('disabled',''); }
        });
    };

}));