namespace Slack.Client.Models.SlackApi
{
    public enum SlackActionIdEnum
    {
        profile_edit,
        profile_update,
        profile_receivers,
        profile_transmitters,
        profile_achievement_likes,
        profile_achievements_catalog,
        profile_short_open_update,
        profile_short_open,
        profile_short_modal_subscribe,
        profile_short_modal_unsubscribe,
        profile_short_modal_like,
        profile_short_modal_unlike,
        profile_achievement_open,
        profile_achievement_close,
        profile_achievement_like, // Лайк ачивки
        profile_achievement_unlike, // Дизлайк ачивки
        profile_likes,
        profile_short_achievements,
        feed_list,
        open_filter,
        search,
        search_filter_select_sex,
        select_male,
        select_female,
        select_male_or_female,
        feed_achievement_open,
        feed_achievement_liked,
        search_all_achievement_types,
        user_agreed
    }
}