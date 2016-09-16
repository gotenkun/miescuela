CKEDITOR.dialog.add('medscapeDialog', function (editor) {
    return {
        title: 'Buscar en Medscape',
        minWidth: 400,
        minHeight: 200,
        contents: [
            {
                id: 'tab-basic',
                label: 'Dato de búsqueda',
                elements: [
                    {
                        type: 'text',
                        id: 'medscape',
                        label: 'Escriba el Texto a Buscar. Recuerde que Medscape está en inglés.',
                        validate: CKEDITOR.dialog.validate.notEmpty("Indique el dato que desea buscar.")
                    }//,
                    //{
                    //    type: 'text',
                    //    id: 'title',
                    //    label: 'Explanation',
                    //    validate: CKEDITOR.dialog.validate.notEmpty("Explanation field cannot be empty.")
                    //}
                ]
            }//,
            //{
            //    id: 'tab-adv',
            //    label: 'Advanced Settings',
            //    elements: [
            //        {
            //            type: 'text',
            //            id: 'id',
            //            label: 'Id'
            //        }
            //    ]
            //}
        ],
        onOk: function () {
            var dialog = this;
            window.open("http://search.medscape.com/reference-search?newSearchRefHome=1&queryText=" + dialog.getValueOf('tab-basic', 'medscape'), "blank");
            

            //var medscape = editor.document.createElement('medscape');
            //medscape.setAttribute('title', dialog.getValueOf('tab-basic', 'title'));
            //medscape.setText(dialog.getValueOf('tab-basic', 'medscape'));

            //var id = dialog.getValueOf('tab-adv', 'id');
            //if (id)
            //    medscape.setAttribute('id', id);

            //editor.insertElement(medscape);
        }
    };
});