
function updateProfile(profileData) {

    const photo = document.getElementById("profile.photo")
    photo.src = profileData.photo

    const name = document.getElementById("profile.name")
    name.innerHTML = profileData.name

    const job = document.getElementById("profile.job")
    job.innerHTML = profileData.job

    const location = document.getElementById("profile.location")
    location.innerHTML = profileData.location

    const phone = document.getElementById("profile.phone")
    phone.innerHTML += profileData.phone
    phone.href = ` tel:${profileData.phone}`

    const email = document.getElementById("profile.email")
    email.innerHTML = profileData.email
    email.href = `$ mailto:${profileData.email}`



}

function updateSoftSkills(profileData) {
    const softskills = document.getElementById('profile.skills.softskills')

    softskills.innerHTML = profileData.skills.softskills.map((skill) => `<li>${skill}</li>`).join('')
}

function updateHardSkills(profileData) {
    const hardskills = document.getElementById('profile.skills.hardskills');
    hardskills.innerHTML = profileData.skills.hardskills.map(logo => ` <li><img src="${logo.logo}" alt="${logo.name}" ,title="${logo.name}" "></li>`).join('')

}

function updateLanguage(profileData){
    const language = document.getElementById("language")
    language.innerHTML =  profileData.languages.map((lang) => `<li>${lang}</li>`).join('')
}

function updateProject(profileData){
    const portfolio = document.getElementById('profile.portfolio')
    portfolio.innerHTML = profileData.portfolio.map((project) => {
        return `<li> <h3 ${project.github ? 'class="github"' :''}">${project.name} </h3>
        <a href="${project.url}" target="_blank">${project.url}<a/> </li> `
    }).join('')
}

(async () => {

    const profileData = await fetchProfileData()
    updateProfile(profileData)
    updateSoftSkills(profileData)
    updateHardSkills(profileData)
    updateLanguage(profileData)
    updateProject(profileData)

})()