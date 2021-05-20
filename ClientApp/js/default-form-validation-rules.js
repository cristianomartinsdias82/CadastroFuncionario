window.defaultFormValidationRules = {
    errorClass: 'is-invalid',
    rules: {
        fullName: {
            required: true
        },
        ssn: {
            required: true
        },
        dob: {
            required: true
        },
        salary: {
            required: true
        },
    },
    messages: {
        fullName: {
            required: '(*) Nome completo é obrigatório'
        },
        ssn: {
            required: '(*) Cpf é obrigatório'
        },
        dob: {
            required: '(*) Data de nascimento é obrigatório'
        },
        salary: {
            required: '(*) Salário é obrigatório'
        }
    }
};