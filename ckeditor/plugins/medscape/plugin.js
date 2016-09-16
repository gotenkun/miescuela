CKEDITOR.plugins.add('medscape', {
    icons: 'medscape',
    init: function (editor) {
        // Plugin logic goes here...
        editor.addCommand('medscape', new CKEDITOR.dialogCommand('medscapeDialog'));
        editor.ui.addButton('medscape', {
            label: 'Buscar en Medscape',
            command: 'medscape',
            toolbar: 'insert'
        });

        CKEDITOR.dialog.add('medscapeDialog', this.path + 'dialogs/medscape.js');
    }
});