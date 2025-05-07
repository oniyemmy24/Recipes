document.addEventListener('DOMContentLoaded', () => {
    const recipeForm = document.getElementById('recipeForm');
    const recipesList = document.getElementById('recipes');

    recipeForm.addEventListener('submit', (event) => {
        event.preventDefault();
        const title = document.getElementById('title').value;
        const ingredients = document.getElementById('ingredients').value;
        const instructions = document.getElementById('instructions').value;

        const recipeItem = document.createElement('li');
        recipeItem.innerHTML = `
            <strong>${title}</strong><br>
            Ingredients: ${ingredients}<br>
            Instructions: ${instructions}
        `;
        recipesList.appendChild(recipeItem);

        // Clear the form
        recipeForm.reset();
    });
});