const {createApp, ref} = Vue;
createApp({
	setup()
	{
		const isloaded = ref(false);
		const sysstatus = ref("");
		const lastupdated = ref("");
		const initsystem = () =>
		{
			isloaded = true;
			sysstatus.value = "System online";
		}
		const combodata = ref([]);
		const selectitem = ref("");
		const fillcombo = () =>
		{
			if(!isloaded)
			{
				alert("Activate the system first!");
			}
			else
			{
				const jsonitems =
				[
					{id: 1, name: "First option"},
					{id: 2, name: "Second option"},
					{id: 3, name: "Third option"}
				];
				combodata.value = jsonitems;
				lastupdated.value = Date.now();
			}
		};
		const textinput = ref('');
		const count = ref(0);
		const items = ref(['1st item']);
		const additem = () =>
		{
			items.value.push(`Item #${items.value.length+1}`);
		};
		const table = ref(Array(5).fill(null).map(() => Array(5).fill("?")));
		const fileuploadhandler = (event) =>
		{
			const file = event.target.files[0];
			if(!file)
			{
				return;
			}
			const read = new FileReader();
			read.onload = (e) =>
			{
				const content = e.target.result;
				const rows = content.trim().split("\n").map(row => row.split(','));
				table.value = rows;
			}
			read.readAsText(file);
		}
		const data = ref(
		{
			"Input 1": "",
			"Input 2": "",
			"Input 3": "",
			"Input 4": "",
			"Input 5": ""
		});
		const submitdata = () =>
		{
			const msg = Object.entries(data.value).map(([key, value]) => `$(key): $(value)`).join("\n");
			alert(`All input data:\n\n$(msg)`);
		}
		return{
			initsystem,
			isloaded,
			sysstatus,
			lastupdated,
			textinput,
			count,
			items,
			additem,
			combodata,
			selectitem,
			fillcombo,
			table,
			fileuploadhandler
		};
	}
}).mount('#app');