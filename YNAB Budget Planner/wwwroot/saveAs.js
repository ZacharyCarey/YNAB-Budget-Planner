function saveAsFile(filename, data) {
    const blob = new Blob([data], { type: 'text' });
    const elem = window.document.createElement('a');
    elem.style.display = 'none';
    elem.href = window.URL.createObjectURL(blob);
    elem.download = filename;
    document.body.appendChild(elem);
    elem.click();
    document.body.removeChild(elem);
    window.URL.revokeObjectURL(elem.href);
}