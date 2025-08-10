async function fetchProfileData(){
    const url = "https://raw.githubusercontent.com/Shirocastle/portfolio/refs/heads/master/data/profile.json"
   const fetching = await fetch(url)
   return  await fetching.json()
}