class GanttChart2 {
    constructor(containerId) {
        this.containerId = containerId;
        this.activities = [];
        this.timeScale = d3.scaleTime();
        this.yScale = d3.scaleBand();
        this.margin = { top: 20, right: 20, bottom: 20, left: 20 };
        this.width = 1000 - this.margin.left - this.margin.right;
        this.height = 500 - this.margin.top - this.margin.bottom;
        this.svg = d3.select(`#${this.containerId}`)
            .append('svg')
            .attr('width', this.width + this.margin.left + this.margin.right)
            .attr('height', this.height + this.margin.top + this.margin.bottom)
            .append('g')
            .attr('transform', `translate(${this.margin.left},${this.margin.top})`);

        this.drag = d3.drag()
            .on('start', this.dragStarted.bind(this))
            .on('drag', this.dragged.bind(this))
            .on('end', this.dragEnded.bind(this));

        this.zoom = d3.zoom()
            .scaleExtent([0.1, 2])
            .on('zoom', this.zoomed.bind(this));

        this.arrow = this.svg.append('defs').append('marker')
            .attr('id', 'arrow')
            .attr('viewBox', '0 -5 10 10')
            .attr('refX', 5)
            .attr('refY', 0)
            .attr('markerWidth', 6)
            .attr('markerHeight', 6)
            .attr('orient', 'auto')
            .append('path')
            .attr('d', 'M0,-5L10,0L0,5')
            .attr('class', 'arrowHead');
   
    }

    addActivity(activity) {
        this.activities.push(activity);
        this.render();
    }

    removeActivity(activityId) {
        this.activities = this.activities.filter(a => a.id !== activityId);
        this.render();
    }

    updateActivity(updatedActivity) {
        let activity = this.activities.find(a => a.id === updatedActivity.id);
        if (activity) {
            Object.assign(activity, updatedActivity);
            this.render();
        }
    }

    render() {
        this.svg.selectAll('*').remove(); // Clear the SVG

        this.timeScale.domain([d3.min(this.activities, a => a.start), d3.max(this.activities, a => a.end)]).range([0, this.width]);
        this.yScale.domain(this.activities.map(a => a.id)).range([0, this.height]);

        this.svg.append('g').attr('transform', `translate(0,${this.height})`).call(d3.axisBottom(this.timeScale));
        this.svg.append('g').call(d3.axisLeft(this.yScale));

        let bars = this.svg.selectAll('.bar')
            .data(this.activities)
            .enter()
            .append('rect')
            .attr('class', 'bar')
            .attr('x', d => this.timeScale(d.start))
            .attr('y', d => this.yScale(d.id))
            .attr('width', d => this.timeScale(d.end) - this.timeScale(d.start))
            .attr('height', this.yScale.bandwidth())
            .attr('fill', d => d.color || '#62d0f0')
            .call(this.drag);

        bars.append('title').text(d => `${d.name}\nStart: ${d.start}\nEnd: ${d.end}`);

        this.svg.call(this.zoom);

        let labels = this.svg.selectAll('.label')
            .data(this.activities)
            .enter()
            .append('text')
            .attr('class', 'label')
            .attr('x', d => this.timeScale(d.start))
            .attr('y', d => this.yScale(d.id) + this.yScale.bandwidth() / 2)
            .text(d => d.name);

        let dependencies = this.svg.selectAll('.dependency')
            .data(this.activities.filter(a => a.dependency))
            .enter()
            .append('line')
            .attr('class', 'dependency')
            .attr('x1', d => this.timeScale(d.start))
            .attr('y1', d => this.yScale(d.id) + this.yScale.bandwidth() / 2)
            .attr('x2', d => this.timeScale(this.activities.find(a => a.id === d.dependency).start))
            .attr('y2', d => this.yScale(d.dependency) + this.yScale.bandwidth() / 2)
            .attr('marker-end', 'url(#arrow)');

        //let criticalPath = this.calculateCriticalPath();
        this.svg.selectAll('.bar')
            .filter(d => criticalPath.includes(d.id))
            .classed('critical', true);
    }

    dragStarted(d) {
        d3.select(this).raise().classed('active', true);
    }

    dragged(d) {
        d.start = this.timeScale.invert(d3.event.x);
        d.end = this.timeScale.invert(d3.event.x + d3.select(this).attr('width'));
        d3.select(this)
            .attr('x', d3.event.x)
            .select('title').text(d => `${ d.name } \nStart: ${ d.start } \nEnd: ${ d.end } `);
    }

    dragEnded(d) {
        d3.select(this).classed('active', false);
    }

    zoomed() {
        this.timeScale.range([0, d3.event.transform.scaleX * this.width]);
        this.svg.selectAll('.bar')
            .attr('x', d => this.timeScale(d.start))
            .attr('width', d => this.timeScale(d.end) - this.timeScale(d.start));
        this.svg.select('.x.axis').call(d3.axisBottom(this.timeScale));
    }
}
