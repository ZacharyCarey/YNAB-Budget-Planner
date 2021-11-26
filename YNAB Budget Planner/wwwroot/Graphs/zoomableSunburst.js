width = 1000;
radius = width / 2;

var arc = d3.arc()
    .startAngle(d => d.x0)
    .endAngle(d => d.x1)
        .padAngle(d => Math.min((d.x1 - d.x0) / 2, 0.005))
        .padRadius(radius / 2)
    .innerRadius(d => d.y0)
    .outerRadius(d => d.y1 - 2)

function labelVisible(d) {
    return (d.x1 - d.x0 > 0) && ((d.y0 + d.y1) / 2 * (d.x1 - d.x0) > 10);
}

function labelTransform(d) {
    const x = (d.x0 + d.x1) / 2 * 180 / Math.PI;
    const y = (d.y0 + d.y1) / 2;
    return `rotate(${x - 90}) translate(${y},0) rotate(${x < 180 ? 0 : 180})`;
}

// Label of an arc
function arcText(d, sKey) {
    var CHAR_SPACE = 7,
        deltaAngle = d.x1 - d.x0,
        r = Math.max(0, (d.y0 + d.y1) / 2),
        perimeter = r * deltaAngle,
        iMinLength = 3, // minimum length of label
        iMaxLength = Math.floor(perimeter / CHAR_SPACE);

    iMaxLength = iMaxLength < iMinLength ? 0 : iMaxLength;
    // Need to tune it better
    return sKey; //(sKey || '').toString().slice(0, iMaxLength);
}

function focusOn(chart, p) {
    /**
     * First time, mark the clicked node as zoomed;
     * Second time, un-mark the node as zoomed.
     * When an already zoomed node is clicked, lets zoom out to its parent or root.
     */
    let target;

    // determine actual node to highlight
    // root will have no parent
    if (p.depth > 1) {
        target = p.bZoomed ? p : (p.children ? p : p.parent);
    } else {
        target = p;
    }
    console.log(target);
    if (target.bZoomed) {
        delete target.bZoomed;
        target = chart.oLastZoomed = chart.aHistory.pop();

        if (!chart.aHistory.length) {
            chart.root.bHighlighted = true;
            target = chart.oLastZoomed = chart.root;
        }
    } else {
        target.bZoomed = true;
        if (chart.oLastZoomed) {
            chart.aHistory.push(chart.oLastZoomed);
        }
        chart.oLastZoomed = target;
    }

    chart.root.each(function (d) {
        var targetY0 = 0;
        var targetY1 = 0;

        if (d == target) {
            targetY0 = 0;
            targetY1 = chart.reduction;
        } else {
            var n = chart.root.height - d.depth + target.depth;
            targetY0 = radius - (n + 1) * chart.unit;
            targetY1 = radius - n * chart.unit;
        }

        d.target = {
            x0: Math.max(0, Math.min(1, (d.x0 - target.x0) / (target.x1 - target.x0))) * 2 * Math.PI,
            x1: Math.max(0, Math.min(1, (d.x1 - target.x0) / (target.x1 - target.x0))) * 2 * Math.PI,
            y0: Math.max(0, targetY0),
            y1: Math.max(0, targetY1)
        };
    });

    const t = chart.g.transition().duration(750);

    // Transition the data on all arcs, even the ones that aren’t visible,
    // so that if this transition is interrupted, entering arcs will start
    // the next transition from the desired position.
    chart.paths.transition(t)
        .tween("data", d => {
            const i = d3.interpolate(d.current, d.target);
            return t => d.current = i(t);
        })
        .attrTween("d", d => () => arc(d.current));

    chart.labels.transition(t)
        .attr("fill-opacity", d => +labelVisible(d.target))
        .attrTween("transform", d => () => labelTransform(d.current));
}

function sliceMouseOver (chart, ev, d) {
    ev.stopPropagation();
    chart.tooltip.style('display', 'inline');
    chart.tooltip.html("<div class=\"tooltip-title\">"
        .concat(tooltipTitle ? tooltipTitle(d.data, d) : "", "</div>")
        .concat(tooltipContent(d.data, d)));
}

function sliceMouseOut(chart) {
    chart.tooltip.style('display', 'none');
}

function getNodeStack(d) {
    var stack = [];
    var curNode = d;

    while (curNode) {
        stack.unshift(curNode);
        curNode = curNode.parent;
    }

    return stack;
}


function generateGraph(element, data) {
    var chart = {};

    chart.color = d3.scaleOrdinal().range(d3.quantize(d3.interpolateRainbow, data.children.length + 1));

    var temp = d3.hierarchy(data)
        .sum(d => d.value)
        .sort((a, b) => b.value - a.value);
    var partition = d3.partition().size([2 * Math.PI, radius]);
    chart.root = partition(temp);
    chart.aHistory = [];



    chart.reduction = chart.root.y1 * 0.5;
    chart.unit = (radius - chart.reduction) / chart.root.height;
    chart.root.each(function (d) {
        if (d == chart.root) {
            d.y1 = chart.reduction;
        } else {
            var n = chart.root.height - d.depth;
            d.y0 = radius - (n + 1) * chart.unit;
            d.y1 = radius - n * chart.unit;
        }
    });

    var format = d3.format(",d");

    chart.oLastZoomed = chart.root;

    chart.root.each(d => d.current = d);

    const container = d3.select(element); //d3.select("div#container");
    chart.svg = container.append("svg")
        .attr("viewBox", [-width / 2, -width / 2, width, width]);

    //Add tooltip
    chart.tooltip = container.append('div')
        .attr('id', 'tooltip')
        .attr('class', 'sunburst-tooltip');
    const htmlTooltip = document.getElementById('tooltip');

    //event to move the tooltip with the mouse
    container.on('mousemove', function (ev) {
        var mouseX = ev.clientX;
        var mouseY = ev.clientY;

        // Prevent tooltip from extending past the sides of the window
        var width = htmlTooltip.offsetWidth; // Width of the tooltip
        var percentage = mouseX / window.innerWidth;
        var dx = -(percentage * width);
        var x = mouseX + dx;


        var dy = 21; // Add offset so tooltip appears below the mouse
        const tooltipPadding = 15; // Pixels from the bottom of the screen before it flips sides
        var height = htmlTooltip.offsetHeight; // Height of the tooltip
        var y = mouseY + dy;

        // Prevent the tooltip from extending past the bottom of the window
        if ((y + height + tooltipPadding) >= window.innerHeight) {
            y = mouseY - dy - height;
        }

        chart.tooltip
            .style('left', x + 'px')
            .style('top', y + 'px');
    });

    //Tooltip title
    if ((typeof tooltipTitle !== "function") || (tooltipTitle.length !== 2)) {
        tooltipTitle = function (data, d) {
            var excludeRoot = false;
            return getNodeStack(d).slice(excludeRoot ? 1 : 0).map(function (d) {
                return d.data.name;
            }).join(' &rarr; ');
        };
    }

    //Temporary tooltip content
    if ((typeof tooltipContent !== "function") || (tooltipContent.length !== 2)) {
        tooltipContent = function (data, d) {
            return "Size: " + format(d.value);
        };
    }

    //Reset focus by clicking on the canvas
    chart.svg.on('click', function () {
        focusOn(chart, chart.root); // Reset zoom on canvas click
    });

    chart.g = chart.svg.append("g");

    chart.paths = chart.g.append("g")
        .attr("fill-opacity", 0.6)
        .selectAll("path")
        .data(chart.root.descendants())
        .enter().append("path")
        .attr("fill", d => { while (d.depth > 1) d = d.parent; return !d.depth ? 'none' : chart.color(d.data.name); })
        .attr("fill-opacity", d => d.children ? 0.6 : 0.4)
        .attr("d", arc)
        .attr("id", function (d, i) {
            return 'cp-' + i;
        })
        .on('mouseover', function (ev, d) {
            sliceMouseOver(chart, ev, d);
        })
        .on('mouseout', function () {
            sliceMouseOut(chart);
        });

    //paths.append("title")
    //    .text(d => `${d.ancestors().map(d => d.data.name).reverse().join("/")}\n${format(d.value)}`);

    chart.paths.filter(d => d.children)
        .style('cursor', 'pointer')
        .on("click", function (ev, p) {
            ev.stopPropagation();
            focusOn(chart, p);
        });

    chart.labels = chart.g.append("g")
        .attr("pointer-events", "none")
        .attr("text-anchor", "middle")
        .selectAll("text")
        .data(chart.root.descendants().filter(d => d.depth))
        .enter().append("text")
        .attr("transform", d => labelTransform(d))
        .attr("fill-opacity", d => +labelVisible(d))
        .attr("dy", "0.35em")
        .attr("clip-path", function (d, i) {
            return 'url(#cp-' + i + ')';
        })
        .text(d => arcText(d, d.data.name));
}