document.addEventListener('input', function (e) {
    
    const diffTargets = document.querySelectorAll('[data-diff-a][data-diff-b]');

    diffTargets.forEach(function (target) {
        const idA = target.getAttribute('data-diff-a');
        const idB = target.getAttribute('data-diff-b');

        const inputA = document.getElementById(idA);
        const inputB = document.getElementById(idB);

       
        if (e.target === inputA || e.target === inputB) {
            const valA = parseFloat(inputA.value) || 0;
            const valB = parseFloat(inputB.value) || 0;
            target.value = (valA - valB).toFixed(2);
        }
    });
});