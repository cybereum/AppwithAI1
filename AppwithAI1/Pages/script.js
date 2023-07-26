const width = document.getElementById("diagram").clientWidth;
const height = document.getElementById("diagram").clientHeight;

const svg = d3.select("#diagram")
    .append("svg")
    .attr("width", width)
    .attr("height", height);

const nodes = [
    { id: "Project Risk", group: 1 },
    { id: "Unknown Unknowns", group: 1 },
    { id: "Known Unknowns", group: 1 },
    { id: "Known Risks", group: 1 },
    { id: "Distributed Governance", group: 2 },
    { id: "Machine Learning", group: 2 },
    { id: "Network Analysis", group: 2 },
    { id: "Development & Planning", group: 3 },
    { id: "Execution & Completion", group: 3 },
];

const links = [
    { source: "Unknown Unknowns", target: "Project Risk" },
    { source: "Known Unknowns", target: "Project Risk" },
    { source: "Known Risks", target: "Project Risk" },
    { source: "Distributed Governance", target: "Known Risks" },
    { source: "Machine Learning", target: "Known Unknowns" },
    { source: "Network Analysis", target: "Unknown Unknowns" },
    { source: "Development & Planning", target: "Distributed Governance" },
    { source: "Development & Planning", target: "Machine Learning" },
    { source: "Development & Planning", target: "Network Analysis" },
    { source: "Execution & Completion", target: "Distributed Governance" },
    { source: "Execution & Completion", target: "Machine Learning" },
    { source: "Execution & Completion", target: "Network Analysis" },
];

const simulation = d3.forceSimulation(nodes)
    .force("link", d3.forceLink(links).id(d => d.id).distance(200))
    .force("charge", d3.forceManyBody().strength(-200))
    .force("center", d3.forceCenter(width / 2, height / 2));

const link = svg.append("g")
    .attr("class", "links")
    .selectAll("line")
    .data(links)
    .join("line")
    .attr("class", "link")
    .attr("stroke-width", 1.5);

const node = svg.append("g")
    .attr("class", "nodes")
    .selectAll("g")
    .data(nodes)
    .join("g");

node.append("circle")
    .attr("class", "node")
    .attr("r", 20)
    .attr("fill", d => d3.schemeCategory10[d.group - 1])
    .call(d3.drag()
        .on("start", dragstarted)
        .on("drag", dragged)
        .on("end", dragended));

node.append("text")
    .attr("dy", ".35em")
    .attr("text-anchor", "middle")
    .text(d => d.id);

simulation.on("tick", () => {
    link
        .attr("x1", d => d.source.x)
        .attr("y1", d => d.source.y)
        .attr("x2", d => d.target.x)
        .attr("y2", d => d.target.y);

    node
        .attr("transform", d => `translate(${d.x}, ${d.y})`);
});

function dragstarted(event, d) {
    if (!event.active) simulation.alphaTarget(0.3).restart();
    d.fx = d.x;
    d.fy = d.y;
}

function dragged(event, d) {
    d.fx = event.x;
    d.fy = event.y;
}

function dragended(event, d) {
    if (!event.active) simulation.alphaTarget(0);
    d.fx = null;
    d.fy = null;
}

