const {createApp, ref} = Vue;
const txt = createApp({
	setup()
	{
		const textinput = ref('');
		return{
			textinput,
		};
	}
});
txt.mount('#txtapp');
const counter = createApp({
	setup()
	{
		const count = ref(0);
		return{
			count
		};
	}
});
counter.mount('#cntapp')
const itemapp = createApp({
	setup()
	{
		const['st', 'nd', 'rd', 'th'];
		const items = ref(['1st item']);
		const additem = () =>
		{
			items.value.push(`Item #${items.value.length+1}`);
		};
		return{
			items,
			additem
		};
	}
});
itemapp.mount('#itemapp');