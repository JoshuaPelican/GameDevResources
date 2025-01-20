$(document).ready(function () {
    var tagsContainer = $('#tagsContainer');
    var tagInput = $('#tagInput');
    var tagsHidden = $('#tagsHidden');

    // Function to render chips
    function renderChips() {
        tagsContainer.empty();
        tagsHidden.val().split(',').forEach(function (tag) {
            if (tag.trim() !== '') {
                tagsContainer.append(`<span class="chip" data-tag="${tag}">${tag} <button type="button" class="close" data-tag="${tag}">&times;</button></span>`);
            }
        });
    }

    // Function to add a tag
    function addTag(tag) {
        var tags = tagsHidden.val().split(',').map(t => t.trim());
        if (!tags.includes(tag)) {
            tags.push(tag);
            tagsHidden.val(tags.join(','));
            renderChips();
            tagInput.val('');
        }
    }

    // Function to remove a tag
    function removeTag(tag) {
        var tags = tagsHidden.val().split(',').filter(t => t.trim() !== tag);
        tagsHidden.val(tags.join(','));
        renderChips();
    }

    // Event listener for adding tags
    tagInput.on('keypress', function (e) {
        if (e.which === 13) { // Enter key
            e.preventDefault();
            var tag = tagInput.val().trim();
            if (tag) {
                addTag(tag);
            }
        }
    });

    // Event listener for removing tags
    tagsContainer.on('click', '.close', function () {
        removeTag($(this).data('tag'));
    });

    // Autocomplete setup
    tagInput.autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '/Resources/GetTagSuggestions',
                dataType: "json",
                data: { term: request.term },
                success: function (data) {
                    response(data.slice(0, 5)); // Limit to top 5 suggestions
                }
            });
        },
        minLength: 2,
        select: function (event, ui) {
            addTag(ui.item.value);
            return false;
        }
    });

    // Initial render
    renderChips();
});